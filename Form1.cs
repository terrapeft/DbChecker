using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;

namespace DbChecker
{
    public partial class Form1 : Form
    {
        private string historyFile = "queries.json";
        private string historyFileName = "queries";
        private int historyPosition = 0;
        private List<string> historyList;
        private bool ctrlK = false;
        private DataTable gridTable;
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();

            resultsDataGridView.DataError += (sender, args) =>
            {
                resultsTextbox.AppendText("DataGridView Error: " + args.Exception.Message + "\r\n");
            };

            AddUsers();
            LoadHistory();
        }

        private void LoadHistory()
        {
            if (!File.Exists(historyFile))
            {
                File.CreateText(historyFile).Close();
            }

            var json = File.ReadAllText(historyFile);
            historyList = JsonConvert.DeserializeObject<List<string>>(json) ??
                new List<string>
                {
                    "SELECT * FROM INFORMATION_SCHEMA.TABLES"
                };

            if (historyList.Any())
            {
                historyPosition = historyList.Count - 1;
                queryTextbox.Text = historyList[historyList.Count - 1];
            }

            historyPositionLabel.Text = $"{historyPosition + 1}/{historyList.Count}";
        }

        private void SaveHistory()
        {
            if (!historyList.Any(i => i.Trim().ToLower().Equals(queryTextbox.Text.Trim().ToLower())))
            {
                historyList.Add(queryTextbox.Text);
                historyPosition = historyList.Count - 1;
                File.WriteAllText(historyFile, JsonConvert.SerializeObject(historyList));
                RefreshPosition();
            }
        }

        private void ClearHistory()
        {
            historyList.RemoveAt(historyPosition);
            File.WriteAllText(historyFile, JsonConvert.SerializeObject(historyList));

            RefreshPosition();
        }

        private void RefreshPosition()
        {
            if (historyPosition == historyList.Count)
            {
                historyPosition--;
            }

            queryTextbox.Text = historyList[historyPosition];
            historyPositionLabel.Text = $"{historyPosition + 1}/{historyList.Count}";
        }

        private void GoLeft()
        {
            if (historyPosition == 0)
            {
                historyPosition = historyList.Count - 1;
            }
            else
            {
                historyPosition--;
            }

            RefreshPosition();
        }

        private void GoRight()
        {
            if (historyPosition == historyList.Count - 1)
            {
                historyPosition = 0;
            }
            else
            {
                historyPosition++;
            }

            RefreshPosition();
        }

        private void GoLast()
        {
            historyPosition = historyList.Count - 1;
            RefreshPosition();
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

        private void Comment()
        {
            if (!string.IsNullOrWhiteSpace(queryTextbox.SelectedText))
            {
                var lines = queryTextbox.SelectedText.Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                var t = string.Join(Environment.NewLine, lines.Select(l => "--" + l));
                queryTextbox.Text = queryTextbox.Text.Replace(queryTextbox.SelectedText, t);
            }
        }

        private void Uncomment()
        {
            if (!string.IsNullOrWhiteSpace(queryTextbox.SelectedText))
            {
                var lines = queryTextbox.SelectedText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var t = string.Join(Environment.NewLine, lines.Select(l => l.TrimStart('-')));
                queryTextbox.Text = queryTextbox.Text.Replace(queryTextbox.SelectedText, t);
            }
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

            var sb = new StringBuilder();
            gridTable = new DataTable();
            var count = 0;

            try
            {
                runButton.Text = "Cancel";
                runButton.Tag = "cancel";
                progressBar1.Visible = true;

                var startedAt = DateTime.Now;

                resultsTextbox.AppendText($"Started at {startedAt:g}.{Environment.NewLine}");

                await Task.Run(() =>
                {
                    var connStr = connStrTextBox.Text ??
                                  ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString;
                    using (var connection = new SqlConnection(connStr))
                    {
                        var cmd = new SqlCommand(queryTextbox.SelectionLength > 0 ? queryTextbox.SelectedText : queryTextbox.Text, connection);
                        cmd.CommandTimeout = 3600;

                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            var resultCount = 0;

                            do
                            {
                                if (reader.FieldCount > 0)
                                    resultCount++;

                                if (tabControl1.SelectedTab == tabPage2) // multiple result sets are not supported by gridTable.Load
                                {
                                    gridTable.Load(reader);
                                    count = gridTable.Rows.Count;
                                    saveResultsButton.Enabled = true;
                                }
                                else
                                {
                                    var columnNames = Enumerable.Range(0, reader.FieldCount)
                                        .Select(reader.GetName)
                                        .ToList();

                                    sb.Append(string.Join(",", columnNames));
                                    sb.AppendLine();

                                    while (reader.Read())
                                    {
                                        count++;
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
                            } while (!reader.IsClosed && reader.NextResult());
                        }
                    }
                });
                resultsDataGridView.DataSource = gridTable;
                if (sb.Length > 0)
                {
                    resultsTextbox.AppendText(sb.ToString());
                    resultsTextbox.AppendText(Environment.NewLine);
                }

                resultsTextbox.AppendText($"Rows loaded: {count}, elapsed time: {(DateTime.Now - startedAt):g}");
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
            if (e.KeyCode == Keys.F5)
            {
                runButton_Click(sender, e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.K)
            {
                ctrlK = true;
                return; // skip "falsefication"
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C && ctrlK)
            {
                Comment();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.U && ctrlK)
            {
                Uncomment();
            }

            if (historyList.Any())
            {
                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.Right)
                {
                    GoRight();
                }

                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.Left)
                {
                    GoLeft();
                }
            }

            ctrlK = false;
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
            var backup = $"_backup_{DateTime.Now:yyyy_MM_dd_hh_mm_ss}.json";
            File.Copy(historyFile, $"{historyFileName}{backup}");
            File.Delete(historyFile);
            historyList.Clear();

            resultsTextbox.AppendText($"Backup saved to: {historyFileName}{backup}{Environment.NewLine}");

            LoadHistory();
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

        private void saveQueryButton_Click(object sender, EventArgs e)
        {
            SaveHistory();
        }

        private void deleteQueryButton_Click(object sender, EventArgs e)
        {
            ClearHistory();
        }

        private void saveResultsButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (gridTable != null && gridTable.Rows.Count > 0)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        resultsDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        resultsDataGridView.RowHeadersVisible = true;
                        resultsDataGridView.SelectAll();

                        var dataObject = resultsDataGridView.GetClipboardContent();
                        if (dataObject != null)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, dataObject.GetData("Csv") as string);
                        }
                    }
                }
            }
        }

        private void rightHistoryButton_Click(object sender, EventArgs e)
        {
            GoRight();
        }

        private void leftHistoryButton_Click(object sender, EventArgs e)
        {
            GoLeft();
        }

        private void lastHistoryButton_Click(object sender, EventArgs e)
        {
            GoLast();
        }

        private void toolStripPanel1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
