using System.IO;

namespace BackofficeTools.Repositories
{
    public class CsvRepository
    {
        private readonly string _path;
        private const string DefaultExtension = ".csv";
        private const string MultiFileSuffix = " - Result ";

        readonly FileRepository _fileRepo = new FileRepository();

        public CsvRepository(string path)
        {
            _path = path;
        }

        public void SaveToFile(params string [] content)
        {
            if (content.Length == 0) return;

            var fileName = _path;
            var file = new FileInfo(_path);
            var hasExtension = !string.IsNullOrEmpty(file.Extension);

            if (content.Length == 1)
            {
                if (!hasExtension)
                {
                    fileName += DefaultExtension;
                }

                _fileRepo.WriteFile(fileName, content[0]);
            }
            else
            {
                var k = 1;
                foreach (var s in content)
                {
                    if (!hasExtension)
                    {
                        fileName += $"{MultiFileSuffix}{k++}{DefaultExtension}";
                    }
                    else
                    {
                        fileName = fileName.Replace(file.Extension, $"{MultiFileSuffix}{k++}.{file.Extension}");
                    }

                    _fileRepo.WriteFile(fileName, s);
                }
            }
        }
    }
}
