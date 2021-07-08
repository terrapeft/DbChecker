using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DbChecker.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        public string SqlFilePath => ConfigurationManager.AppSettings.Get("sqlFilePath");

        public string SqlPath => ConfigurationManager.AppSettings.Get("sqlPath");

        public string DefaultQuery => ConfigurationManager.AppSettings.Get("defaultQuery");

        public string SelectedConnectionString {
            get
            {
                RefreshConnectionStrings();
                return ConfigurationManager.AppSettings.Get("lastConnStrName");
            }
            set
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var lastConnStrName = doc.XPathSelectElement("//appSettings/add[@key='lastConnStrName']");
                lastConnStrName?.SetAttributeValue("value", value);
                doc.Save(ConfigurationManager.AppSettings.Get("config"));
            }
        }

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
        }

        public void DeleteConnectionString(string name)
        {
            var doc = XDocument.Load("connections.config");
            var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{name}']");
            connStr?.Remove();

            doc.Save("connections.config");
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
        string SqlFilePath { get; }
        string SqlPath { get; }
        string DefaultQuery { get; }
        string SelectedConnectionString { get; set; }
        string SelectedGroup { get; set; }
        string SelectedScript { get; set; }
        ConnectionStringSettings[] ConnectionStrings { get; }
        void SaveConnectionString(string name, string value);
        void DeleteConnectionString(string name);
    }
}
