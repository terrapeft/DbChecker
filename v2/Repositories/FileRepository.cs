using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DbChecker.Repositories
{
    public class FileRepository : IFileRepository
    {
        public string ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                File.CreateText(path).Close();
            }

            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }

    public interface IFileRepository
    {
        string ReadFile(string path);

        void WriteFile(string path, string content);
    }
}
