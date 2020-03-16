using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DbChecker
{
    public partial class Form1 : Form
    {
        private const string delimiter = ">>>>>>>";
        private int historyPosition = 0;
        List<string> historyList = new List<string>();
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
            AddUsers();
            LoadHistory();
        }

        private void LoadHistory()
        {
            if (!File.Exists("queries.txt"))
            {
                File.CreateText("queries.txt").Close();
            }

            var sb = new StringBuilder();
            foreach (var line in File.ReadLines("queries.txt"))
            {
                if (line.Trim() != delimiter)
                {
                    sb.AppendLine(line);
                }
                else
                {
                    var query = sb.ToString().Trim();
                    if (query.Length > 0)
                    {
                        historyList.Add(sb.ToString());
                    }

                    sb.Clear();
                }
            }

            if (historyList.Any())
                queryTextbox.Text = historyList[0];
        }

        private void SaveHistory()
        {
            if (!checkBox1.Checked)
                return;

            if (!historyList.Any(i => i.Trim().ToLower().Equals(queryTextbox.Text.Trim().ToLower())))
            {
                File.AppendAllText(
                    "queries.txt",
                    $"{queryTextbox.Text}{Environment.NewLine}{delimiter}{Environment.NewLine}");

                historyList.Add(queryTextbox.Text);
            }
        }

        private void AddUsers()
        {
            connStrComboBox.Items.Clear();
            ConfigurationManager.RefreshSection("connectionStrings");

            connStrComboBox.Items.AddRange(ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().ToArray());
            connStrComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();

            connStrComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("lastConnStrPosition"));
        }

        #region Event handlers

        private async void runButton_Click(object sender, EventArgs e)
        {
            if (runButton.Tag == "cancel")
            {
                cts?.Cancel();
                return;
            }

            SaveHistory();

            cts = new CancellationTokenSource();
            var token = cts.Token;

            var progressHandler = new Progress<string>(value =>
            {
                resultsTextbox.AppendText(value.ToString());
            });

            var progress = progressHandler as IProgress<string>;
            var sb = new StringBuilder();

            try
            {
                runButton.Text = "Cancel";
                runButton.Tag = "cancel";
                progressBar1.Visible = true;

                await Task.Run(() =>
                {
                    var connStr = connStrTextBox.Text ??
                                  ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString;
                    using (var connection = new SqlConnection(connStr))
                    {
                        var cmd = new SqlCommand(queryTextbox.Text, connection);
                        cmd.CommandTimeout = 3600;

                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                .Select(reader.GetName)
                                .ToList();

                            sb.Append(string.Join(",", columnNames));
                            sb.AppendLine();

                            while (reader.Read())
                            {
                                token.ThrowIfCancellationRequested();

                                for (var i = 0; i < reader.FieldCount; i++)
                                {
                                    var value = reader[i].ToString();
                                    if (value.Contains(","))
                                        value = "\"" + value + "\"";

                                    sb.Append(value.Replace(Environment.NewLine, " ") + ",");
                                }

                                sb.Length--;
                                sb.AppendLine();
                            }
                        }
                    }
                });
                resultsTextbox.AppendText(sb.ToString());
                resultsTextbox.AppendText(Environment.NewLine);
            }
            catch (OperationCanceledException)
            {
                resultsTextbox.AppendText(sb.ToString());
                resultsTextbox.AppendText(Environment.NewLine);
                resultsTextbox.AppendText("\r\nCancelled.\r\n");
            }
            catch (Exception ex)
            {
                resultsTextbox.AppendText(ex.Message);
                resultsTextbox.AppendText(Environment.NewLine);
            }

            runButton.Text = "Run";
            runButton.Tag = string.Empty;
            progressBar1.Visible = false;
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connStrTextBox.Text = ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString;

            var connStrIndex = connStrComboBox.SelectedIndex;
            var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
            var lastConnStrPosition = doc.XPathSelectElement("//appSettings/add[@key='lastConnStrPosition']");
            lastConnStrPosition?.SetAttributeValue("value", connStrIndex);
            doc.Save(ConfigurationManager.AppSettings.Get("config"));
        }

        private void queryTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!historyList.Any()) return;

            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.Right)
            {
                if (historyPosition == historyList.Count - 1)
                {
                    historyPosition = 0;
                }
                else
                {
                    historyPosition++;
                }

                queryTextbox.Text = historyList[historyPosition];
            }

            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.Left)
            {
                if (historyPosition == 0)
                {
                    historyPosition = historyList.Count - 1;
                }
                else
                {
                    historyPosition--;
                }

                queryTextbox.Text = historyList[historyPosition];
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var connStrName = (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text;
            if (connStrName != null)
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var connStrs = doc.XPathSelectElement("//connectionStrings");
                var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{connStrName}']");
                if (connStr == null)
                {
                    connStr = new XElement("add",
                        new XAttribute("name", connStrName),
                        new XAttribute("connectionString", connStrTextBox.Text));
                    connStrs.Add(connStr);
                }
                else
                {
                    connStr.SetAttributeValue("connectionString", connStrTextBox.Text);
                }

                doc.Save(ConfigurationManager.AppSettings.Get("config"));
                AddUsers();
                connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(connStrName);
            }
        }

        private void wipeHistoryButton_Click(object sender, EventArgs e)
        {
            File.Delete("queries.txt");
            File.Create("queries.txt").Close();
            historyList.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var connStrName = (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text;
            if (connStrName != null)
            {
                var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));
                var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{connStrName}']");
                connStr?.Remove();

                doc.Save(ConfigurationManager.AppSettings.Get("config"));
                AddUsers();
            }
        }

        #endregion
    }
}
