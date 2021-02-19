using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbChecker.Controls;
using DbChecker.Models;
using DbChecker.Repositories;
using DbChecker.Views;

/// <summary>
/// Icon set: https://www.iconfinder.com/iconsets/basic-user-interface-elements
/// </summary>
namespace DbChecker
{
    public partial class AppForm : Form
    {
        private ISqlRepository _sqlRepository;
        private IConfigRepository _configRepository;
        private List<Group> _groups;
        private QueryBox _uiBox;

        public string SelectedConnectionString
        {
            get
            {
                var s = connStrComboBox.SelectedItem as ConnectionStringSettings;
                return s?.ConnectionString;
            }
        }

        public AppForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _sqlRepository = new SqlRepository();

            AddConnectionStrings();
            _groups = _sqlRepository.GetSql();

            groupsControl.SelectedGroupChanged += (sender, g) =>
            {
                _uiBox = new QueryBox(g);
                queryAndResultsSplitContainer.Panel1.Controls.Clear();
                queryAndResultsSplitContainer.Panel1.Controls.Add(_uiBox.CreateBox());
            };

            groupsControl.Bind(_groups);

            connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(_configRepository.SelectedConnectionString);
        }

        private void AddConnectionStrings()
        {
            connStrComboBox.Items.Clear();
            ConfigurationManager.RefreshSection("connectionStrings");

            connStrComboBox.Items.AddRange(_configRepository.ConnectionStrings);
            connStrComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_uiBox != null)
            {
                _sqlRepository.PatchAndSave(_uiBox.GetModel());
            }
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ei = new EditableItem
            {
                ItemType = ItemType.ConnectionString,
                Name = (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text,
                Value = ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString
            };

            itemEditor.Item = ei;
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            var runner = new SqlRunner(_uiBox.Script);
            await runner.GetDataSet(SelectedConnectionString).ContinueWith(r =>
            {
                if (r.Result?.Results?.Tables.Count > 0)
                {
                    resultsBox.BeginInvoke(new Action<DataSet>(SetTables), r.Result?.Results);
                }
                else
                {
                    resultsBox.BeginInvoke(new Action<string>(SetText), r.Result?.Messages);
                }
            });
        }

        private void SetTables(DataSet dataSet)
        {
            resultsBox.Tables = dataSet;
        }

        private void SetText(string text)
        {
            resultsBox.Messages = text;
        }

        private void AppForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                runButton_Click(sender, e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveButton_Click(null, null);
                return; // skip "falsefication"
            }
        }

        private void generateInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = CsvFileReader.Load(openFileDialog1.FileName);
                //_uiBox.Script queryTextbox.Text = SqlGenerator.GenerateSelectIntoTemp(dt);
            }
        }

        private void itemEditor_OnSave(object sender, EditableItem e)
        {
            if (e.ItemType == ItemType.ConnectionString)
            {
                _configRepository.SaveConnectionString(e.Name, e.Value);

                AddConnectionStrings();
                connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(e.Name);
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedConnectionString))
            {
                _configRepository.SelectedConnectionString = SelectedConnectionString;
            }

            if (groupsControl.CurrentGroup != null)
            {
                _configRepository.SelectedGroup = groupsControl.CurrentGroup.Name;
            }
        }
    }
}
