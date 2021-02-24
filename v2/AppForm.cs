using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbChecker.Controls;
using DbChecker.Models;
using DbChecker.Repositories;
using DbChecker.Views;

// Icon set: https://www.iconfinder.com/iconsets/basic-user-interface-elements

namespace DbChecker
{
    public partial class AppForm : Form
    {
        private ISqlRepository _sqlRepository;
        private IConfigRepository _configRepository;
        private List<Group> _groups;
        private QueryBox _uiBox;

        private CancellationTokenSource cts;

        private const string DefaultGroupName = "New Group";
        private const string DefaultScriptName = "New Script";

        public string SelectedConnectionString
        {
            get
            {
                var s = connStrComboBox.SelectedItem as ConnectionStringSettings;
                return s?.ConnectionString;
            }
        }

        public string SelectedConnectionStringName => (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text;

        public AppForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _sqlRepository = new SqlRepository();

            groupsControl.SelectedGroupChanged += GroupsControl_SelectedGroupChanged;
            groupsControl.RenamingGroup += GroupsControl_RenamingGroup;

            SetState();
        }

        private void SetState()
        {
            AddConnectionStrings();
            _groups = _sqlRepository.GetSql();
            groupsControl.Bind(_groups);
            groupsControl.SelectItem(_configRepository.SelectedGroup);
            connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(_configRepository.SelectedConnectionString);
        }

        private void GroupsControl_RenamingGroup(object sender, Group e)
        {
            if (e == null) return;
            RenameGroup(e);
        }

        private void RenameGroup(Group group)
        {
            itemEditor.Item = new EditableItem
            {
                Id = group.Guid.ToString(),
                Value = group.Name,
                ItemType = ItemType.Group
            };
        }

        private void UiBox_RenamingScript(object sender, Script e)
        {
            if (e == null) return;
            RenameScript(e);
        }

        private void RenameScript(Script script)
        {
            itemEditor.Item = new EditableItem
            {
                Id = script.Guid.ToString(),
                Value = script.Name,
                ItemType = ItemType.Script
            };
        }

        private void GroupsControl_SelectedGroupChanged(object sender, Group g)
        {
            SetGroup(g);
            SaveLastUsedGroupAndScript();
        }

        private void SetGroup(Group g)
        {
            var gr = g;
            if (g.Name == GroupControl.NewGroupName)
            {
                gr = new Group
                {
                    Name = DefaultGroupName
                };

                _groups.Add(gr);
                RenameGroup(gr);
            }
            else
            {
                SetConnectionString();
            }

            _uiBox = new QueryBox(gr);
            _uiBox.RenamingScript += UiBox_RenamingScript;
            _uiBox.DeletingScript += UiBox_DeletingScript;
            queryAndResultsSplitContainer.Panel1.Controls.Clear();
            queryAndResultsSplitContainer.Panel1.Controls.Add(_uiBox.CreateBox());
        }

        private void UiBox_DeletingScript(object sender, Script e)
        {
            var group = _groups.FirstOrDefault(g => g.Scripts.Contains(g.Scripts.FirstOrDefault(s => s.Guid == e.Guid)));
            var script = _groups
                .SelectMany(g => g.Scripts)
                .FirstOrDefault(s => s.Guid == e.Guid);

            group.Scripts.Remove(script);

            SaveModel();
            SetState();
        }

        private void AddConnectionStrings()
        {
            connStrComboBox.Items.Clear();
            connStrComboBox.Text = string.Empty;

            connStrComboBox.Items.AddRange(_configRepository.ConnectionStrings);
            connStrComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();

            if (connStrComboBox.Items.Count > 0)
            {
                connStrComboBox.SelectedIndex = 0;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveModel();
        }

        private void SaveModel()
        {
            if (_uiBox != null)
            {
                _sqlRepository.PatchAndSave(_uiBox.GetModel());
            }
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnectionString();
        }

        private void SetConnectionString()
        {
            var ei = new EditableItem
            {
                ItemType = ItemType.ConnectionString,
                Id = SelectedConnectionStringName,
                Value = SelectedConnectionString
            };

            itemEditor.Item = ei;
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            if (runButton.Tag == "cancel")
            {
                cts?.Cancel();
                return;
            }

            runButton.Tag = "cancel";
            progressBar.Visible = true;
            cts = new CancellationTokenSource();
            var runner = new SqlRunner(_uiBox.Script, cts.Token);
            await runner.GetDataSet(SelectedConnectionString)
                .ContinueWith(r =>
            {
                if (r.Result?.Results?.Tables.Count > 0)
                {
                    //resultsBox.BeginInvoke(new Action<DataSet>(SetTables), r.Result?.Results);
                    SetTables(r.Result?.Results);
                }
                else
                {
                    //resultsBox.BeginInvoke(new Action<string>(SetText), r.Result?.Messages);
                    SetText(r.Result?.Messages);
                }

                progressBar.Visible = false;
                runButton.Tag = string.Empty;
                resultsLabel.Text = string.Join("/", r.Result?.Results?.Tables
                    .Cast<DataTable>()
                    .Where(t => t.Rows.Count > 0) ?? Array.Empty<DataTable>());
            });
        }

        private void SetTables(DataSet dataSet)
        {
            resultsBox.Dataset = dataSet;
        }

        private void SetText(string text)
        {
            resultsBox.Messages = text;
        }

        private void AppForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (itemEditor.Item.ItemType == ItemType.Group)
                {
                    if (groupsControl.CurrentValue != _configRepository.SelectedGroup)
                    {
                        groupsControl.SelectItem(_configRepository.SelectedGroup);
                    }
                    else
                    {
                        SetConnectionString();
                    }
                }

                if (itemEditor.Item.ItemType == ItemType.Script)
                {
                    SetConnectionString();
                }
            }

            if (e.KeyCode == Keys.F5)
            {
                runButton_Click(sender, e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveModel();
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
            switch (e.ItemType)
            {
                case ItemType.ConnectionString:
                    var newName = SelectedConnectionStringName;
                    _configRepository.SaveConnectionString(newName, e.Value);
                    AddConnectionStrings();
                    connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(newName);
                    break;

                case ItemType.Group:
                    var edg = sender as ItemEditor;
                    var group = _groups.Find(g => g.Guid == Guid.Parse(e.Id));
                    group.Name = edg.Item.Value;
                    _configRepository.SelectedGroup = group.Name;
                    SaveModel();
                    SetState();
                    break;

                case ItemType.Script:
                    var eds = sender as ItemEditor;
                    var script = _groups
                        .SelectMany(g => g.Scripts)
                        .FirstOrDefault(s => s.Guid == Guid.Parse(e.Id));
                    script.Name = eds.Item.Value;
                    _uiBox.Page.Text = script.Name;
                    _configRepository.SelectedScript = script.Name;
                    SaveModel();
                    SetState();
                    break;
            }
        }
        private void itemEditor_OnDelete(object sender, EditableItem e)
        {
            if (e.ItemType == ItemType.ConnectionString)
            {
                _configRepository.DeleteConnectionString(e.Id);
                AddConnectionStrings();
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedConnectionStringName))
            {
                _configRepository.SelectedConnectionString = SelectedConnectionStringName;
            }

            SaveLastUsedGroupAndScript();
            SaveModel();
        }

        private void SaveLastUsedGroupAndScript()
        {
            if (groupsControl.CurrentGroup != null && groupsControl.CurrentGroup.Name != GroupControl.NewGroupName)
            {
                _configRepository.SelectedGroup = groupsControl.CurrentGroup.Name;
            }

            if (_uiBox.Page != null && groupsControl.CurrentGroup.Name != GroupControl.NewGroupName)
            {
                _configRepository.SelectedScript = _uiBox.Page.Text;
            }
        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataObject = resultsBox.SelectedResult;
            if (dataObject == null) return;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                new CsvRepository(saveFileDialog1.FileName).SaveToFile(dataObject.GetData("Csv") as string);
            }
        }

        private void saveAllResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            foreach (var result in resultsBox.Results)
            {
                new CsvRepository(saveFileDialog1.FileName).SaveToFile(result.GetData("Csv") as string);
            }
        }

    }
}
