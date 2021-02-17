using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;

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

        public ConnectionStringSettings[] ConnectionStrings
        {
            get => ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToArray();
        }
    }

    public interface IConfigRepository
    {
        string SqlFilePath { get; set; }
        string DefaultQuery { get; set; }
        ConnectionStringSettings[] ConnectionStrings { get; }
    }
}
