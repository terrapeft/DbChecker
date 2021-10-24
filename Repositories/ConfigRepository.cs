using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using BackofficeTools.Models;

namespace BackofficeTools.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private const string SnippetPrefix = "Snippet_";

        public string MetaFilePath => ConfigurationManager.AppSettings.Get("metaFilePath");

        public string SqlPath => ConfigurationManager.AppSettings.Get("sqlPath");

        public string DefaultQuery => ConfigurationManager.AppSettings.Get("defaultQuery");

        public string SelectedGroup
        {
            get
            {
                RefreshAppSettings();
                return ConfigurationManager.AppSettings.Get("lastGroupName");
            }
            set
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var lastGroupName = doc.XPathSelectElement("//appSettings/add[@key='lastGroupName']");
                lastGroupName?.SetAttributeValue("value", value);
                doc.Save(ConfigurationManager.AppSettings.Get("config"));
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public string SelectedScript
        {
            get
            {
                RefreshAppSettings();
                return ConfigurationManager.AppSettings.Get("lastScriptName");
            }
            set
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var lastScriptName = doc.XPathSelectElement("//appSettings/add[@key='lastScriptName']");
                lastScriptName?.SetAttributeValue("value", value);
                doc.Save(ConfigurationManager.AppSettings.Get("config"));
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public ConnectionStringSettings[] ConnectionStrings
        {
            get => ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToArray();
        }

        public void SaveConnectionString(string name, string value)
        {
            var doc = XDocument.Load("connections.config");
            var connStrs = doc.XPathSelectElement("//connectionStrings");
            var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{name}']");

            if (connStr == null && ConnectionStrings.Any(s => s.Name == name))
            {
                // skip values from machine.config
                return;
            }

            if (connStr == null)
            {
                connStr = new XElement("add",
                    new XAttribute("name", name),
                    new XAttribute("connectionString", value));
                connStrs.Add(connStr);
            }
            else
            {
                connStr.SetAttributeValue("connectionString", value);
            }

            doc.Save("connections.config");
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public void RenameConnectionString(string newName, string oldName)
        {
            var doc = XDocument.Load("connections.config");
            var connStrs = doc.XPathSelectElement("//connectionStrings");
            var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{oldName}']");

            if (connStr == null) return;

            connStr.Attribute("name").Value = newName;
            doc.Save("connections.config");
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public void DeleteConnectionString(string name)
        {
            var doc = XDocument.Load("connections.config");
            var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{name}']");
            connStr?.Remove();

            doc.Save("connections.config");
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public Snippet[] Snippets
        {
            get
            {
                return ConfigurationManager.AppSettings
                    .AllKeys
                    .Where(n => n.StartsWith(SnippetPrefix))
                    .Select(n => new Snippet {
                        Name = SplitCamelCase(n.Replace(SnippetPrefix, string.Empty)),
                        Text = ConfigurationManager.AppSettings[n] })
                    .ToArray();
            }
        }

        private string SplitCamelCase(string source)
        {
            return string.Join(" ", Regex.Split(source, @"(?<!^)(?=[A-Z])"));
        }

        private void RefreshConnectionStrings()
        {
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void RefreshAppSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public interface IConfigRepository
    {
        string MetaFilePath { get; }
        string SqlPath { get; }
        string DefaultQuery { get; }
        string SelectedGroup { get; set; }
        string SelectedScript { get; set; }
        ConnectionStringSettings[] ConnectionStrings { get; }
        Snippet[] Snippets { get; }
        void SaveConnectionString(string name, string value);
        void RenameConnectionString(string newName, string oldName);
        void DeleteConnectionString(string name);
    }
}
