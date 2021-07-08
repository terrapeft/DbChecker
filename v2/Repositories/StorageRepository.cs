using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var files = _fileRepository.FindFiles(path, "*.sql");
            var group = new Group { Name = groupName };

            foreach (var file in files)
            {
                var script = new Script { Name = Path.GetFileNameWithoutExtension(file.FullName) };
                var filePath = Path.Combine(path, file.Name);
                GetContent(filePath, script);

                group.Scripts.Add(script);
            }

            return group;
        }

        private void GetContent(string path, Script script)
        {
            var content = _fileRepository.ReadLines(path).ToArray();

            if (content.Any() && content[0].StartsWith(Script.CONNSTR_COMMENT))
            {
                script.ConnectionString = content[0].Replace(Script.CONNSTR_COMMENT, string.Empty);
                script.Text = string.Join(Environment.NewLine, content.Skip(1));
            }
            else
            {
                script.Text = string.Join(Environment.NewLine, content);
            }
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

        public void SaveScript(string groupName, Script script)
        {
            var path = GetGroupPath(groupName);
            _fileRepository.CreateDirectory(path);

            if (script.Text.StartsWith(Script.CONNSTR_COMMENT))
            {
                script.Text = script.Text.Substring(script.Text.IndexOf(Environment.NewLine));
            }

            _fileRepository.WriteFile(Path.Combine(path, $"{script.Name}.sql"), script.ConnectionStringComment, script.Text);
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
        //void DeleteScript(string groupName, Script script);
        //void DeleteGroup(Group group);
    }

}
