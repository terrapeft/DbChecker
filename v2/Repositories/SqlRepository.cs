using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbChecker.Models;
using Newtonsoft.Json;

namespace DbChecker.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly IConfigRepository _configRepository;
        private readonly IFileRepository _fileRepository;

        public SqlRepository()
        {
            _configRepository = new ConfigRepository();
            _fileRepository = new FileRepository();
        }

        public List<Group> GetSql()
        {
            var json = _fileRepository.ReadFile(_configRepository.SqlFilePath);

            return JsonConvert.DeserializeObject<List<Group>>(json) ??
                   new List<Group>
                   {
                       new Group
                       {
                           Name = "Default",
                           Scripts = new List<Script>
                           {
                               new Script
                               {
                                   Name = "Default",
                                   Text = _configRepository.DefaultQuery
                               }
                           }
                       }

                   };
        }

        public void SaveSql(List<Group> scripts)
        {
            _fileRepository.WriteFile(_configRepository.SqlFilePath, JsonConvert.SerializeObject(scripts));
        }

        public void PatchAndSave(Group group)
        {
            var currentFile = GetSql();
            var node = currentFile.FirstOrDefault(n => n.Guid == group.Guid);
            if (node != null)
            {
                currentFile[currentFile.IndexOf(node)] = group;
            }
            else
            {
                currentFile.Add(group);
            }

            SaveSql(currentFile);
        }
    }


    public interface ISqlRepository
    {
        List<Group> GetSql();
        void SaveSql(List<Group> scripts);
        void PatchAndSave(Group @group);
    }

}
