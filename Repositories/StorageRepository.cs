using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BackofficeTools.Models;
using Newtonsoft.Json;

namespace BackofficeTools.Repositories
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
                var group = ReadOrCreateGroupWithMeta(groupName);
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
                ChangeScriptNameInMetadata(groupName, scriptName, newScriptName);
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

            UpdateScriptInMetadata(groupName, script);
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

        public void UpdateScriptInMetadata(string groupName, Script script)
        {
            var path = GetGroupPath(groupName);
            var jsonFile = Path.Combine(path, _configRepository.MetaFilePath);
            var currentMeta = ReadMetadata(jsonFile);
            var scriptMeta = currentMeta.Scripts.Single(s => s.Name.Equals(script.Name));
            scriptMeta.ConnectionString = script.ConnectionString;
            WriteMetadata(jsonFile, currentMeta);
        }

        public void ChangeScriptNameInMetadata(string groupName, string oldName, string newName)
        {
            if (groupName == null) return;
            if (oldName == null) return;
            if (newName == null) return;

            var path = EnsureDirectory(groupName);
            var jsonFile = Path.Combine(path, _configRepository.MetaFilePath);
            var group = ReadMetadata(jsonFile);

            var matches = group.Scripts.Where(s => s.Name.Equals(oldName));

            foreach (var script in matches)
            {
                script.Name = newName;
            }

            WriteMetadata(jsonFile, group);
        }

        public void ChangeConnectionNameInMetadata(string newName, string oldName)
        {
            if (oldName == null) return;
            if (newName == null) return;

            foreach (var path in Directory.GetDirectories(_configRepository.SqlPath))
            {
                var jsonFile = Path.Combine(path, _configRepository.MetaFilePath);
                var group = ReadMetadata(jsonFile);

                if (group == null) continue;

                var matches = group.Scripts
                    .Where(s => s.ConnectionString != null && s.ConnectionString.Equals(oldName));

                foreach (var script in matches)
                {
                    script.ConnectionString = newName;
                }

                WriteMetadata(jsonFile, group);
            }
        }

        private Group ReadOrCreateGroupWithMeta(string groupName)
        {
            var path = GetGroupPath(groupName);
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
                group = ReadMetadata(jsonFile);

                if (group == null)
                {
                    group = new Group { Name = groupName };
                    newGroup = true;
                }
            }

            // files in folder
            var fileNames = _fileRepository.FindFiles(path, "*.sql")
                .OrderBy(f => f.CreationTime)
                .Select(f => Path.GetFileNameWithoutExtension(f.Name))
                .ToList();

            // files in meta, deleted from folder
            var deletedFiles = group.Scripts.Select(s => s.Name)
                .Except(fileNames)
                .ToList();

            // files in folder, missed in meta
            var missingFiles = fileNames
                .Except(group.Scripts.Select(s => s.Name))
                .ToList();

            if (newGroup || missingFiles.Any() || deletedFiles.Any())
            {
                if (newGroup || missingFiles.Any())
                {
                    foreach (var file in missingFiles)
                    {
                        group.Scripts.Add(new Script {Name = Path.GetFileNameWithoutExtension(file)});
                    }
                }

                if (deletedFiles.Any())
                {
                    foreach (var file in deletedFiles)
                    {
                        group.Scripts.Remove(group.Scripts.Single(s => s.Name.Equals(file)));
                    }
                }

                WriteMetadata(jsonFile, group);
            }

            foreach (var script in group.Scripts)
            {
                var filePath = Path.Combine(path, $"{script.Name}.sql");
                GetContent(filePath, script);
            }

            return group;
        }

        private Group ReadMetadata(string jsonFile)
        {
            var json = _fileRepository.ReadFile(jsonFile);
            return JsonConvert.DeserializeObject<Group>(json);
        }

        private void WriteMetadata(string jsonFile, Group group)
        {
            _fileRepository.WriteFile(jsonFile, JsonConvert.SerializeObject(group));
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
        void UpdateScriptInMetadata(string groupName, Script script);
        void RenameScript(string groupName, string scriptName, string newScriptName);
        void SaveOrRenameScript(string groupName, string scriptName, string newScriptName, string script);
        void CreateOrRenameGroup(string newName, string oldName = null);
        void ChangeConnectionNameInMetadata(string newName, string oldName);
    }
}
