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

        public string SelectedConnectionString {
            get
            {
                return ConfigurationManager.AppSettings.Get("lastConnStrName");
            }
            set
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var lastConnStrName = doc.XPathSelectElement("//appSettings/add[@key='lastConnStrName']");
                lastConnStrName?.SetAttributeValue("value", value);
            }
        }

        public string SelectedGroup
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("lastGroupName");
            }
            set
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var lastGroupName = doc.XPathSelectElement("//appSettings/add[@key='lastGroupName']");
                lastGroupName?.SetAttributeValue("value", value);
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
    }

    public interface IConfigRepository
    {
        string SqlFilePath { get; set; }
        string DefaultQuery { get; set; }
        string SelectedConnectionString { get; set; }
        string SelectedGroup { get; set; }
        ConnectionStringSettings[] ConnectionStrings { get; }
        void SaveConnectionString(string name, string value);
    }
}
