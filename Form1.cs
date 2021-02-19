using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;
using CsvHelper;
using FastColoredTextBoxNS;

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
        private bool changed = false;
        private bool autoSave = false;

        public Form1()
        {
            InitializeComponent();

            resultsDataGridView.DataError += (sender, args) =>
            {
                resultsTextbox.AppendText("DataGridView Error: " + args.Exception.Message + "\r\n");
            };

            AddConnectionStrings();
            LoadParametersFromConfig();
            LoadHistory();

            connStrTextBox.SelectionLength = 0;
            queryTextbox.Focus();
        }

        private void LoadParametersFromConfig()
        {
            autoSave = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("autoSave"));
            autoSaveToolStripMenuItem.Checked = autoSave;
            autoSaveToolStripMenuItem.BackColor = autoSave ? Color.BurlyWood : Color.Transparent;

            queryTextbox.WordWrap = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("wrap"));
            wrapToolStripMenuItem.Checked = queryTextbox.WordWrap;
            wrapToolStripMenuItem.BackColor = queryTextbox.WordWrap ? Color.BurlyWood : Color.Transparent;

            connStrComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("lastConnStrPosition"));

            historyPosition = Convert.ToInt32(ConfigurationManager.AppSettings.Get("lastQueryPosition"));
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
                if (historyPosition == 0 || historyPosition >= historyList.Count)
                {
                    historyPosition = historyList.Count - 1;
                }

                queryTextbox.Text = historyList[historyPosition];
            }

            historyPositionLabel.Text = $"{historyPosition + 1}/{historyList.Count}";
        }

        private void SaveHistory(bool update = false)
        {
            if (update)
            {
                historyList[historyPosition] = queryTextbox.Text;
                File.WriteAllText(historyFile, JsonConvert.SerializeObject(historyList));
                RefreshPosition();
            }
            else if (autoSave && !historyList.Any(i => i.Trim().ToLower().Equals(queryTextbox.Text.Trim().ToLower())))
            {
                historyList.Add(queryTextbox.Text);
                historyPosition = historyList.Count - 1;
                File.WriteAllText(historyFile, JsonConvert.SerializeObject(historyList));
                RefreshPosition();
            }
        }

        private void ClearHistory()
        {
            historyList.RemoveAt(historyPosition--);
            File.WriteAllText(historyFile, JsonConvert.SerializeObject(historyList));

            RefreshPosition();
        }

        private void RefreshPosition()
        {
            if (historyPosition < 0)
            {
                historyPosition = 0;
            }

            if (historyPosition >= historyList.Count)
            {
                historyPosition = historyList.Count - 1;
            }

            queryTextbox.Text = historyList[historyPosition];
            historyPositionLabel.Text = $"{historyPosition + 1}/{historyList.Count}";
            Text = Text.Trim('*');
            changed = false;
        }

        private void GoLeft()
        {
            SaveHistory(true);

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
            SaveHistory(true);

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

        private void GoFirst()
        {
            SaveHistory(true);

            historyPosition = 0;
            RefreshPosition();
        }

        private void GoLast()
        {
            SaveHistory(true);

            historyPosition = historyList.Count - 1;
            RefreshPosition();
        }

        private void AddConnectionStrings()
        {
            connStrComboBox.Items.Clear();
            ConfigurationManager.RefreshSection("connectionStrings");

            connStrComboBox.Items.AddRange(ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().ToArray());
            connStrComboBox.ComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();
        }

        private void Comment()
        {
            if (!string.IsNullOrWhiteSpace(queryTextbox.SelectedText))
            {
                var lines = queryTextbox.SelectedText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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
            if (runStripMenuItem.Tag == "cancel")
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
                runStripMenuItem.Text = "Cancel";
                runStripMenuItem.Tag = "cancel";
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
                                    saveResultsToolStripMenuItem.Enabled = true;
                                    gridResultCountLabel.Text = $"Results: {count}";
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

                tabControl1.SelectedTab = tabPage1;
            }
            catch (Exception ex)
            {
                resultsTextbox.AppendText(ex.Message);
                resultsTextbox.AppendText(Environment.NewLine);

                tabControl1.SelectedTab = tabPage1;
            }

            if (gridTable.Rows.Count == 0)
            {
                tabControl1.SelectedTab = tabPage1;
            }

            runStripMenuItem.Text = "Run";
            runStripMenuItem.Tag = string.Empty;
            progressBar1.Visible = false;
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connStrTextBox.Text = ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString;
        }

        private void queryTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                runButton_Click(sender, e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                saveQueryButton_Click(null, null);
                return; // skip "falsefication"
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
                var doc = XDocument.Load("connections.config");
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

                doc.Save("connections.config");
                AddConnectionStrings();
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

            historyPosition = 0;

            LoadHistory();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var connStrName = (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text;
            if (connStrName != null)
            {
                var doc = XDocument.Load("connections.config");
                var connStr = doc.XPathSelectElement($"//connectionStrings/add[@name='{connStrName}']");
                connStr?.Remove();

                doc.Save("connections.config");
                AddConnectionStrings();
            }
        }

        #endregion

        private void saveQueryButton_Click(object sender, EventArgs e)
        {
            SaveHistory(true);
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

        private void firstHistoryButton_Click(object sender, EventArgs e)
        {
            GoFirst();
        }

        private void csvButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = CsvFileReader.Load(openFileDialog1.FileName);
                queryTextbox.Text = SqlGenerator.GenerateSelectIntoTemp(dt);
            }
        }

        private void queryTextbox_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            var formatter = new FastColoredTextBox { Text = historyList[historyPosition] };

            if (queryTextbox.Text != formatter.Text)
            {
                Text = Text.Trim('*') + "*";
                changed = true;
            }
            else
            {
                Text = Text.Trim('*');
                changed = false;
            }
        }

        private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queryTextbox.WordWrap = !queryTextbox.WordWrap;
            wrapToolStripMenuItem.Checked = queryTextbox.WordWrap;
            wrapToolStripMenuItem.BackColor = queryTextbox.WordWrap ? Color.BurlyWood : Color.Transparent;
        }

        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoSave = !autoSave;
            autoSaveToolStripMenuItem.Checked = autoSave;
            autoSaveToolStripMenuItem.BackColor = autoSave ? Color.BurlyWood : Color.Transparent;
        }

        private void addQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory(true);
            queryTextbox.Text = string.Empty;
            SaveHistory();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var doc = XDocument.Load(ConfigurationManager.AppSettings.Get("config"));

            var lastConnStrPosition = doc.XPathSelectElement("//appSettings/add[@key='lastConnStrPosition']");
            lastConnStrPosition?.SetAttributeValue("value", connStrComboBox.SelectedIndex);

            var lastQueryPosition = doc.XPathSelectElement("//appSettings/add[@key='lastQueryPosition']");
            lastQueryPosition?.SetAttributeValue("value", historyPosition);

            var autoSaveParam = doc.XPathSelectElement("//appSettings/add[@key='autoSave']");
            autoSaveParam?.SetAttributeValue("value", autoSave);

            var wrapParam = doc.XPathSelectElement("//appSettings/add[@key='wrap']");
            wrapParam?.SetAttributeValue("value", wrapToolStripMenuItem.Checked);

            doc.Save(ConfigurationManager.AppSettings.Get("config"));

            SaveHistory(true);
        }
    }
}
