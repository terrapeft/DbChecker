using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
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
        private readonly IStorageRepository _sqlRepository;
        private readonly IConfigRepository _configRepository;
        private List<Group> _groups;
        private QueryBox _uiBox;

        private CancellationTokenSource cts;

        private const string _defaultGroupName = "Common Scripts";

        public string DefaultGroupName
        {
            get
            {
                var ix = _sqlRepository.GetGroupNameIndex(_defaultGroupName);
                return ix > 0 ? $"{_defaultGroupName} {ix}": _defaultGroupName;
            }
        }

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

            Directory.CreateDirectory(_configRepository.SqlPath);

            groupsControl.SelectedGroupChanged += GroupsControl_SelectedGroupChanged;
            groupsControl.RenamingGroup += GroupsControl_RenamingGroup;

            resultsLabel.Text = string.Empty;
            startLabel.Text = string.Empty;

            SetState();
        }

        private void SetState()
        {
            ShowProgressBar();

            AddConnectionStrings();
            ////_groups = _sqlRepository.ReadGroupNames();
            groupsControl.Bind(_groups);
            groupsControl.SelectItem(_configRepository.SelectedGroup);

            HideProgressBar();
        }

        private void GroupsControl_RenamingGroup(object sender, Group e)
        {
            if (e == null) return;
            SetItemEditor(e);
        }

        private void SetItemEditor(Group group)
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
            SetItemEditor(e);
        }

        private void SetItemEditor(Script script)
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
                gr = CreateGroup();
                _groups.Add(gr);
                SetItemEditor(gr);
            }
            else
            {
                SetConnectionStringValue();
            }

            //if (g.Name != GroupControl.NewGroupName)
            //{
                gr = _sqlRepository.ReadGroup(gr.Name);
                if (gr != null)
                {
                    CreateTheUIBox(gr);
                }
                //}

            itemEditor.SetFocus();
        }

        private Group CreateGroupWithScript(string groupName = null, string scriptName = null)
        {
            var gr = CreateGroup(groupName);
            gr.Scripts.Add(CreateScript(scriptName));

            return gr;
        }

        private Script CreateScript(string name = null)
        {
            return new Script
            {
                Name = name,
                ConnectionString = SelectedConnectionString
            };
        }


        private Group CreateGroup(string name = null)
        {
            return new Group
            {
                Name = name ?? DefaultGroupName
            };
        }

        private void CreateTheUIBox(Group gr)
        {
            _uiBox = new QueryBox(gr);
            _uiBox.RenamingScript += UiBox_RenamingScript;
            _uiBox.DeletingScript += UiBox_DeletingScript;
            queryAndResultsSplitContainer.Panel1.Controls.Clear();
            queryAndResultsSplitContainer.Panel1.Controls.Add(_uiBox.CreateBox());
        }

        private void UiBox_DeletingScript(object sender, Script e)
        {
            // delete from model
            var group = _groups.FirstOrDefault(g => g.Scripts.Contains(g.Scripts.FirstOrDefault(s => s.Guid == e.Guid)));

            if (group != null)
            {
                var script = group.Scripts.FirstOrDefault(s => s.Guid == e.Guid);

                if (script != null)
                {
                    group.Scripts.Remove(script);
                }
            }

            // delete file
            var gr = _uiBox.GetModel();
            _sqlRepository.DeleteScript(gr.Name, e);

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
                connStrComboBox.SelectedIndex = !string.IsNullOrEmpty(_configRepository.SelectedConnectionString)
                    ? connStrComboBox.FindStringExact(_configRepository.SelectedConnectionString)
                    : 0;
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
                _sqlRepository.SaveGroup(_uiBox.GetModel());
            }
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnectionStringValue();
        }

        private void SetConnectionStringValue()
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

            var startedAt = DateTime.Now;
            startLabel.Text = $"Started at {startedAt:g}";

            runButton.Tag = "cancel";
            runButton.Text = "Cancel";
            runButton.BackColor = Color.LightCoral;

            SetTables(null);
            //SetText();
            ShowProgressBar();
            cts = new CancellationTokenSource();
            var script = _uiBox.HasTextSelection ? _uiBox.TextSelection : _uiBox.Script;
            var runner = new SqlRunner(script, cts.Token);
            await runner
                .GetDataSet(SelectedConnectionString)
                .ContinueWith(r =>
            {
                if (r.Result?.Results?.Tables.Count > 0)
                {
                    resultsBox.BeginInvoke(new Action<DataSet>(SetTables), r.Result?.Results);
                }
                else
                {
                    resultsBox.BeginInvoke(new Action<string>(SetText), r.Result?.Messages);
                }

                this.BeginInvoke(new Action<DataTableCollection, Script, DateTime> (QueryFinished), r.Result?.Results?.Tables, _uiBox.Script, startedAt);
            });
        }

        private void ShowProgressBar()
        {
            progressBar.Visible = true;
        }

        private void HideProgressBar()
        {
            progressBar.Visible = false;
        }

        private void QueryFinished(DataTableCollection tables, Script script, DateTime startedAt)
        {
            HideProgressBar();

            script.ConnectionString = SelectedConnectionString;

            runButton.Tag = string.Empty;
            runButton.Text = "Run";
            runButton.BackColor = Color.LightGreen;

            if (tables != null)
            {
                resultsLabel.Text = "Results: " + string.Join("/", tables
                    .Cast<DataTable>()
                    .Where(t => t.Rows.Count > 0)
                    .Select(t => t.Rows.Count)
                );
            }

            startLabel.Text = $"Elapsed time: {(DateTime.Now - startedAt):g}";
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
                        SetConnectionStringValue();
                    }
                }

                if (itemEditor.Item.ItemType == ItemType.Script)
                {
                    SetConnectionStringValue();
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
                if (_uiBox == null)
                {
                    CreateTheUIBox(CreateGroupWithScript("CSV Generator", Path.GetFileName(openFileDialog1.FileName)));
                }

                _uiBox.SetTextForCurrentTab(SqlGenerator.GenerateSelectIntoTemp(dt));
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
                    if (_uiBox == null)
                    {
                        var group = _groups.Find(g => g.Guid == Guid.Parse(e.Id));
                        group.Name = edg.Item.Value;
                        CreateTheUIBox(group);
                    }
                    _configRepository.SelectedGroup = edg.Item.Value;
                    SaveModel();
                    SetState();

                    break;

                case ItemType.Script:
                    var eds = sender as ItemEditor;
                    var oldName = _uiBox.Script.Name;
                    var m = _uiBox.GetModel();
                    var script = m.Scripts
                        .FirstOrDefault(s => s.Guid == Guid.Parse(e.Id));
                    script.Name = e.Value;
                    _uiBox.Page.Text = e.Value;
                    _configRepository.SelectedScript = e.Value;
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

            if (ModifierKeys != Keys.Control)
            {
                SaveModel();
            }
        }

        private void SaveLastUsedGroupAndScript()
        {
            if (groupsControl.CurrentGroup != null && groupsControl.CurrentGroup.Name != GroupControl.NewGroupName)
            {
                _configRepository.SelectedGroup = groupsControl.CurrentGroup.Name;
            }

            if (_uiBox?.Page != null && groupsControl.CurrentGroup?.Name != GroupControl.NewGroupName)
            {
                _configRepository.SelectedScript = _uiBox.Page.Text;
            }
        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProgressBar();

            var dataObject = resultsBox.SelectedResult;
            if (dataObject == null) return;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                new CsvRepository(saveFileDialog1.FileName).SaveToFile(dataObject.GetData("Csv") as string);
            }

            HideProgressBar();
        }

        private void saveAllResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProgressBar();

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            foreach (var result in resultsBox.Results)
            {
                new CsvRepository($"{saveFileDialog1.FileName}_{result.Name}").SaveToFile(result.DataObject.GetData("Csv") as string);
            }

            HideProgressBar();
        }

        //private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Icons taken on https://icons8.ru", "Icons");
        //}

        private void generateFromValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = CsvFileReader.Load(openFileDialog1.FileName);
                if (_uiBox == null)
                {
                    CreateTheUIBox(CreateGroupWithScript("CSV Generator", Path.GetFileName(openFileDialog1.FileName)));
                }

                _uiBox.SetTextForCurrentTab(SqlGenerator.GenerateSelectFromValues(dt));
            }
        }
    }
}
