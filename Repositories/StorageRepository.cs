using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var files = _fileRepository.FindFiles(path, "*.sql");
                var group = new Group {Name = groupName};

                foreach (var file in files)
                {
                    var script = new Script {Name = Path.GetFileNameWithoutExtension(file.FullName)};
                    var filePath = Path.Combine(path, file.Name);
                    GetContent(filePath, script);

                    group.Scripts.Add(script);
                }

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

        //public string GetIndexedFullFileName(string groupName, string name)
        //{
        //    var path = EnsureDirectory(groupName);
        //    var ix = GetScriptNameIndex(groupName, name);
        //    return ix > 0 ? Path.Combine(path, $"{name} {ix}.sql") : Path.Combine(path, name);
        //}

        //public string GetIndexedDirectoryName(string groupName, string name)
        //{
        //    var path = EnsureDirectory(groupName);
        //    var ix = GetGroupNameIndex(groupName);
        //    return ix > 0 ? Path.Combine(path, $"{name} {ix}") : Path.Combine(path, name);
        //}

        //public int GetScriptNameIndex(string groupName, string name)
        //{
        //    var path = GetGroupPath(groupName);
        //    var files = Directory.GetFiles(path, $"{name}*");
        //    return _fileRepository.GetNextIndex(files);
        //}

        //public int GetGroupNameIndex(string groupName)
        //{
        //    var files = Directory.GetDirectories(_configRepository.SqlPath, $"{groupName}*");
        //    return _fileRepository.GetNextIndex(files);
        //}
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
        //int GetScriptNameIndex(string groupName, string scriptName);
        //int GetGroupNameIndex(string groupName);
        //string GetIndexedFullFileName(string groupName, string name);
        //string GetIndexedDirectoryName(string groupName, string name);
    }

}
