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

        public List<Group> GetGroupNamesOrInit()
        {
            var groupNames = new List<Group>();

            var dirs = _fileRepository.FindDirectories(_configRepository.SqlPath);
            foreach (var dir in dirs)
            {
                groupNames.Add(new Group { Name = dir.Name });
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

        private void GetContent(string path, Script script)
        {
            var content = _fileRepository.ReadLines(path).ToArray();
            script.Text = string.Join(Environment.NewLine, content);
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

        public void RenameScript(string groupName, string scriptName, string newScriptName)
        {
            var path = EnsureDirectory(groupName);
            _fileRepository.RenameFile(
                Path.Combine(path, scriptName),
                Path.Combine(path, newScriptName));
        }

        public void SaveScript(string groupName, Script script)
        {
            var path = EnsureDirectory(groupName);
            _fileRepository.WriteFile(Path.Combine(path, $"{script.Name}.sql"), script.Text);
        }

        public void DeleteScript(string groupName, Script script)
        {
            var path = Path.Combine(GetGroupPath(groupName), $"{script.Name}.sql");
            _fileRepository.DeleteFile(path);
        }

        public void DeleteGroup(Group group)
        {
            _fileRepository.DeleteDirectory(GetGroupPath(group.Name));
        }

        public string GetIndexedFullFileName(string groupName, string name)
        {
            var path = EnsureDirectory(groupName);
            var ix = GetScriptNameIndex(groupName, name);
            return ix > 0 ? Path.Combine(path, $"{name} {ix}.sql") : Path.Combine(path, name);
        }

        public string GetIndexedDirectoryName(string groupName, string name)
        {
            var path = EnsureDirectory(groupName);
            var ix = GetGroupNameIndex(groupName);
            return ix > 0 ? Path.Combine(path, $"{name} {ix}") : Path.Combine(path, name);
        }

        public int GetScriptNameIndex(string groupName, string name)
        {
            var path = GetGroupPath(groupName);
            var files = Directory.GetFiles(path, $"{name}*");
            return _fileRepository.GetNextIndex(files);
        }

        public int GetGroupNameIndex(string groupName)
        {
            var files = Directory.GetDirectories(_configRepository.SqlPath, $"{groupName}*");
            return _fileRepository.GetNextIndex(files);
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
        List<Group> GetGroupNamesOrInit();
        Group ReadGroup(string groupName);
        void SaveAll(List<Group> scripts);
        void SaveGroup(Group group);
        void SaveScript(string groupName, Script script);
        void DeleteScript(string groupName, Script script);
        void DeleteGroup(Group group);
        int GetScriptNameIndex(string groupName, string scriptName);
        int GetGroupNameIndex(string groupName);
        string GetIndexedFullFileName(string groupName, string name);
        string GetIndexedDirectoryName(string groupName, string name);
    }

}
