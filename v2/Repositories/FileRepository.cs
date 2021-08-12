using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        public void WriteFile(string path, params string[] content)
        {
            File.WriteAllText(GetBasePath(path), string.Join(Environment.NewLine, content));
        }

        public void RenameFile(string oldPath, string newPath)
        {
            if (File.Exists(oldPath))
            {
                File.Move(oldPath, newPath);
            }
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

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void RenameDirectory(string oldPath, string newPath)
        {
            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
            }
        }

        public void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private int GetLastFileNameIndex(string path)
        {
            if (File.Exists(path))
            {
                return GetNextIndex(new[] { path });
            }

            return -1;
        }

        private int GetNextIndex(string[] names)
        {
            if (!names.Any())
            {
                return -1;
            }

            var matches = new List<int> {0};

            foreach (var f in names)
            {
                var reg = new Regex(@".*(?<index>\d+)");
                var match = reg.Match(f);
                if (match.Success)
                {
                    matches.Add(Convert.ToInt32(match.Groups["index"].Value));
                }
            }

            return matches.Max() + 1;
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
        void DeleteFile(string path);
        void DeleteDirectory(string path);
        //int GetNextIndex(string[] names);
        //int GetLastFileNameIndex(string path);
        void RenameDirectory(string oldPath, string newPath);
        void RenameFile(string oldPath, string newPath);
    }
}
