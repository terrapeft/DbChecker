using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Newtonsoft.Json;

namespace DbChecker.Repositories
{
    public class FileRepository : IFileRepository
    {
        public string ReadFile(string relativePath)
        {
            var path = GetBasePath(relativePath);

            if (!File.Exists(path))
            {
                File.CreateText(path).Close();
            }

            return File.ReadAllText(path);
        }

        public IEnumerable<string> ReadLines(string relativePath)
        {
            var path = GetBasePath(relativePath);

            if (!File.Exists(path))
            {
                File.CreateText(path).Close();
            }

            return File.ReadLines(path);
        }

        public void WriteFile(string path, params string [] content)
        {
            File.WriteAllText(GetBasePath(path), string.Join(Environment.NewLine, content));
        }

        public DirectoryInfo[] FindDirectories(string path)
        {
            var dir = new DirectoryInfo(GetBasePath(path));
            return !dir.Exists ? new DirectoryInfo[0] : dir.GetDirectories();
        }

        public FileInfo[] FindFiles(string path, string filter)
        {
            var dir = new DirectoryInfo(path);
            return dir.GetFiles(filter);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }

        public string GetBasePath(string relativePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        }
    }

    public interface IFileRepository
    {
        DirectoryInfo[] FindDirectories(string path);
        string ReadFile(string path);
        IEnumerable<string> ReadLines(string path);
        void WriteFile(string path, params string[] content);
        FileInfo[] FindFiles(string path, string filter);
        DirectoryInfo CreateDirectory(string path);
    }
}
