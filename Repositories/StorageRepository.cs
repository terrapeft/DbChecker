using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbChecker.Controls;
using DbChecker.Models;
using Newtonsoft.Json;

namespace DbChecker.Repositories
{
    public class SqlRepository : IStorageRepository
    {


        private readonly IConfigRepository _configRepository;
        private readonly IFileRepository _fileRepository;

        public SqlRepository()
        {
            _configRepository = new ConfigRepository();
            _fileRepository = new FileRepository();
        }

        /// <summary>
        /// Read folders from disk.
        /// </summary>
        /// <returns></returns>
        public List<string> ReadGroupNames()
        {
            var groupNames = new List<string>();

            var dirs = _fileRepository.FindDirectories(_configRepository.SqlPath);
            foreach (var dir in dirs)
            {
                groupNames.Add(dir.Name);
            }

            return groupNames;
        }

        public Group ReadGroup(string groupName)
        {
            var path = GetGroupPath(groupName);

            if (Directory.Exists(path))
            {
                var group = ReadOrCreateGroupWithMeta(path, groupName);
                return group;
            }

            return null;
        }

        public void SaveAll(List<Group> scripts)
        {
            foreach (var group in scripts)
            {
                SaveGroup(group);
            }
        }

        public void SaveGroup(Group group)
        {
            foreach (var script in group.Scripts)
            {
                SaveScript(group.Name, script);
            }
        }

        public void SaveOrRenameScript(string groupName, string scriptName, string newScriptName, string script)
        {
            var path = EnsureDirectory(groupName);
            if (File.Exists(Path.Combine(path, $"{scriptName}.sql")))
            {
                RenameScript(groupName, scriptName, newScriptName);
            }

            SaveScript(groupName, newScriptName, script);
        }

        public void RenameScript(string groupName, string scriptName, string newScriptName)
        {
            var path = EnsureDirectory(groupName);
            _fileRepository.RenameFile(
                Path.Combine(path, $"{scriptName}.sql"),
                Path.Combine(path, $"{newScriptName}.sql"));
        }

        public void SaveScript(string groupName, Script script)
        {
            var path = EnsureDirectory(groupName);
            _fileRepository.WriteFile(Path.Combine(path, $"{script.Name}.sql"), script.Text);
        }

        public void DeleteScript(string groupName, string script)
        {
            var path = Path.Combine(GetGroupPath(groupName), $"{script}.sql");
            _fileRepository.DeleteFile(path);
        }

        public void DeleteGroup(string groupName)
        {
            _fileRepository.DeleteDirectory(GetGroupPath(groupName));
        }

        public void CreateOrRenameGroup(string newName, string oldName)
        {
            if (oldName == MainWindow.NewGroupName || newName == oldName)
            {
                EnsureDirectory(newName);
            }
            else
            {
                var oldPath = GetGroupPath(oldName);

                if (Directory.Exists(oldPath))
                {
                    var newPath = GetGroupPath(newName);
                    _fileRepository.RenameDirectory(oldPath, newPath);
                }
            }
        }

        private Group ReadOrCreateGroupWithMeta(string path, string groupName)
        {
            var jsonFile = Path.Combine(path, _configRepository.MetaFilePath);
            var newGroup = false;
            Group group = null;

            if (!File.Exists(jsonFile))
            {
                group = new Group { Name = groupName };
                newGroup = true;
            }
            else
            {
                var json = _fileRepository.ReadFile(jsonFile);
                group = JsonConvert.DeserializeObject<Group>(json);
            }

            var fileNames = _fileRepository.FindFiles(path, "*.sql")
                .OrderBy(f => f.CreationTime)
                .Select(f => Path.GetFileNameWithoutExtension(f.Name))
                .ToList();

            var missingFiles = fileNames
                .Except(group.Scripts.Select(s => s.Name))
                .ToList();

            if (newGroup || missingFiles.Any())
            {
                foreach (var file in missingFiles)
                {
                    group.Scripts.Add(new Script { Name = Path.GetFileNameWithoutExtension(file) });
                }

                _fileRepository.WriteFile(jsonFile, JsonConvert.SerializeObject(group));
            }

            foreach (var script in group.Scripts)
            {
                var filePath = Path.Combine(path, $"{script.Name}.sql");
                GetContent(filePath, script);
            }

            return group;
        }


        private void GetContent(string path, Script script)
        {
            var content = _fileRepository.ReadLines(path).ToArray();
            script.Text = string.Join(Environment.NewLine, content);
        }

        private void SaveScript(string groupName, string scriptName, string script)
        {
            var path = EnsureDirectory(groupName);
            _fileRepository.WriteFile(Path.Combine(path, $"{scriptName}.sql"), script);
        }

        private string EnsureDirectory(string groupName)
        {
            var path = GetGroupPath(groupName);
            _fileRepository.CreateDirectory(path);
            return path;
        }

        private string GetGroupPath(string groupName)
        {
            return Path.Combine(_configRepository.SqlPath, groupName);
        }
    }


    public interface IStorageRepository
    {
        List<string> ReadGroupNames();
        Group ReadGroup(string groupName);
        void SaveAll(List<Group> scripts);
        void SaveGroup(Group group);
        void SaveScript(string groupName, Script script);
        void DeleteScript(string groupName, string script);
        void DeleteGroup(string groupName);
        void RenameScript(string groupName, string scriptName, string newScriptName);
        void SaveOrRenameScript(string groupName, string scriptName, string newScriptName, string script);
        void CreateOrRenameGroup(string newName, string oldName = null);
    }
}
