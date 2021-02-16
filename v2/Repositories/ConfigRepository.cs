using System;
using System.Configuration;
using System.Drawing;

namespace DbChecker.Repositories
{
    public class ConfigRepository: IConfigRepository
    {
        public string SqlFilePath
        {
            get => ConfigurationManager.AppSettings.Get("sqlFilePath");
            set { }
        }

        public string DefaultQuery
        {
            get => ConfigurationManager.AppSettings.Get("defaultQuery");
            set { }
        }

    }

    public interface IConfigRepository
    {
        string SqlFilePath { get; set; }
        string DefaultQuery { get; set; }
    }
}
