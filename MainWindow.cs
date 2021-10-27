using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BackofficeTools.Models;
using BackofficeTools.Repositories;
using GroupBox = BackofficeTools.Controls.GroupBox;

namespace BackofficeTools
{
    public partial class MainWindow : Form
    {
        public const string NewGroupName = "<Add new group>";
        public const string NewConnectionStringName = "<Add new connection>";

        private readonly IStorageRepository _storageRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IFileRepository _fileRepository;

        private ItemType _currentItemType;
        private string _currentItemOriginalValue;
        private string _currentItemOriginalName;
        private DateTime _prevClick;
        private GroupBox _currentGroupBox;
        private CancellationTokenSource cts;

        public string SelectedConnectionString
        {
            get
            {
                var s = connStrComboBox.SelectedItem as ConnectionStringSettings;
                return s?.ConnectionString;
            }
        }

        public string SelectedConnectionStringName => (connStrComboBox.SelectedItem as ConnectionStringSettings)?.Name ?? connStrComboBox.Text;

        public string SelectedGroupName => groupNamesComboBox.Text;

        public string SelectedValue
        {
            get => valueTextBox.Text;
            set => valueTextBox.Text = value;
        }

        public string SelectedScriptSource => _currentGroupBox?.Text;

        public Script SelectedScript => _currentGroupBox?.SelectedScript;


        public MainWindow()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _fileRepository = new FileRepository();
            _storageRepository = new SqlRepository();

            Directory.CreateDirectory(_configRepository.SqlPath);

            resultsLabel.Text = string.Empty;
            startLabel.Text = string.Empty;
            messageLabel.Text = string.Empty;

            AddConnectionStrings();
            AddGroupNames(_storageRepository.ReadGroupNames());
            AddSnippets();

            // this will trigger the SelectedIndexChanged event with binding
            SelectGroupName(_configRepository.SelectedGroup);

            if (string.IsNullOrEmpty(SelectedGroupName))
            {
                LoadTabs();
            }
        }

        #region Private methods

        #region Common

        private void AddSnippets()
        {
            snippetsToolStripMenuItem.DropDownItems.Clear();

            foreach (var snippet in _configRepository.Snippets)
            {
                var item = new ToolStripMenuItem();

                item.Text = snippet.Name;
                item.Click += (sender, args) =>
                {
                    _currentGroupBox.AppendTextToCurrentTab(snippet.Text);
                };

                snippetsToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void ConfigureNameEditing(string text, ItemType itemType)
        {
            _currentItemOriginalName = text;
            _currentItemType = itemType;
        }

        private void ConfigureValueEditing(string text, ItemType type)
        {
            _currentItemType = type;
            _currentItemOriginalValue = text;
            SelectedValue = text;

            valueTextBox.SelectAll();
            valueTextBox.Focus();
        }

        private void ShowProgressBar()
        {
            progressBar.Visible = true;
        }

        private void HideProgressBar()
        {
            progressBar.Visible = false;
        }

        private void PublishResults(DataSet dataSet)
        {
            resultsBox.Dataset = dataSet;
        }

        private void ShowResultMessage(string text)
        {
            resultsBox.Messages = text;
        }

        private void SaveCurrentGroup()
        {
            if (_currentGroupBox != null)
            {
                var group = _currentGroupBox.GetModel(SelectedGroupName);
                _storageRepository.SaveGroup(group);
            }
        }

        #endregion

        #region Group Names

        private void AddGroupNames(IEnumerable<string> groups)
        {
            groupNamesComboBox.Items.Clear();
            groupNamesComboBox.Text = string.Empty;
            groupNamesComboBox.Items.Add(NewGroupName);
            groupNamesComboBox.Items.AddRange(groups.ToArray());
        }

        private void SelectGroupName(string name)
        {
            groupNamesComboBox.SelectedIndex = groupNamesComboBox.FindStringExact(name);

            if (groupNamesComboBox.SelectedIndex == -1 && groupNamesComboBox.Items.Count > 1)
            {
                groupNamesComboBox.SelectedIndex = 1; // do not select the NewGroupName;
            }
        }

        private void SelectConnectionString(string name)
        {
            connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(name);
        }

        private bool HasSelectedGroup()
        {
            return groupNamesComboBox.SelectedIndex != -1 && SelectedGroupName != NewGroupName;
        }

        private void SaveLastUsedGroupAndScript()
        {
            if (HasSelectedGroup())
            {
                _configRepository.SelectedGroup = SelectedGroupName;
            }

            if (!string.IsNullOrEmpty(_currentGroupBox?.TabText) && HasSelectedGroup())
            {
                _configRepository.SelectedScript = _currentGroupBox.TabText;
            }
        }

        #endregion

        #region Group Tabs

        private void LoadTabs(Group group = null)
        {
            _currentGroupBox = new GroupBox();
            _currentGroupBox.RenamingScript += GroupBoxOnRenamingScript;
            _currentGroupBox.DeletingScript += GroupBoxOnDeletingScript;
            _currentGroupBox.SelectingTab += GroupBoxOnSelectingTab;

            queryAndResultsSplitContainer.Panel1.Controls.Clear();
            queryAndResultsSplitContainer.Panel1.Controls.Add(_currentGroupBox.CreateBox(group));
        }

        private void GroupBoxOnDeletingScript(object sender, string e)
        {
            _storageRepository.DeleteScript(SelectedGroupName, e);
            _currentGroupBox.RemoveSelectedTab();
        }

        private void GroupBoxOnRenamingScript(object sender, string e)
        {
            ConfigureValueEditing(e, ItemType.Script);
        }

        private void GroupBoxOnSelectingTab(object sender, string e)
        {
            if (!string.IsNullOrWhiteSpace(e))
            {
                SelectConnectionString(e);
            }
        }

        #endregion

        #region Connection strings

        private void AddConnectionStrings()
        {
            connStrComboBox.Items.Clear();
            connStrComboBox.Text = string.Empty;
            connStrComboBox.Items.Add(new ConnectionStringSettings(NewConnectionStringName, null));
            connStrComboBox.Items.AddRange(_configRepository.ConnectionStrings);
            connStrComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();
        }

        #endregion

        #region Event handlers

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureValueEditing(SelectedConnectionString, ItemType.ConnectionString);
        }

        private void groupNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedGroupName == NewGroupName)
            {
                ConfigureNameEditing(SelectedGroupName, ItemType.Group);
                groupNamesComboBox.SelectAll();
                groupNamesComboBox.Focus();
            }
            else
            {
                LoadTabs(_storageRepository.ReadGroup(SelectedGroupName));
                SelectConnectionString(SelectedScript?.ConnectionString);
            }
        }

        //private void groupNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
        //    {
        //        StartRenaming(SelectedGroupName, ItemType.Group);
        //    }

        //    _prevClick = DateTime.Now;
        //}

        //private void connStrComboBox_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
        //    {
        //        StartRenaming(SelectedConnectionString, ItemType.ConnectionString);
        //    }

        //    _prevClick = DateTime.Now;
        //}

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (_currentItemType)
            {
                case ItemType.ConnectionStringName:
                    if (SelectedConnectionStringName == NewConnectionStringName) return;
                    var newName = SelectedConnectionStringName;
                    _configRepository.RenameConnectionString(newName, _currentItemOriginalName);
                    _storageRepository.ChangeConnectionNameInMetadata(newName, _currentItemOriginalName);
                    AddConnectionStrings();
                    SelectConnectionString(newName);
                    break;
                case ItemType.ConnectionString:
                    if (SelectedConnectionStringName == NewConnectionStringName) return;

                    _configRepository.SaveConnectionString(SelectedConnectionStringName, SelectedValue);
                    //_storageRepository.ChangeConnectionNameInMetadata(SelectedConnectionStringName, _currentItemOriginalName);
                    AddConnectionStrings();
                    SelectConnectionString(SelectedConnectionStringName); // works for a new item
                    _currentGroupBox?.SetFocus();
                    break;

                case ItemType.Group:
                    if (SelectedGroupName == NewGroupName) return;
                    var newGName = SelectedGroupName;
                    _storageRepository.CreateOrRenameGroup(newGName, _currentItemOriginalName);
                    AddGroupNames(_storageRepository.ReadGroupNames());
                    SelectGroupName(newGName);
                    _currentGroupBox?.SetFocus();
                    break;

                case ItemType.Script:
                    if (!HasSelectedGroup())
                    {
                        messageLabel.Text = "Choose group before saving.";
                        return;
                    }

                    _storageRepository.SaveOrRenameScript(SelectedGroupName, _currentItemOriginalValue, SelectedValue, SelectedScriptSource);
                    _currentGroupBox.TabText = SelectedValue;
                    _currentGroupBox.SetFocus();
                    break;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            switch (_currentItemType)
            {
                case ItemType.ConnectionString:
                    _configRepository.DeleteConnectionString(SelectedConnectionStringName);
                    SelectedValue = null;
                    AddConnectionStrings();
                    break;

                case ItemType.Group:
                    _storageRepository.DeleteGroup(SelectedGroupName);
                    AddGroupNames(_storageRepository.ReadGroupNames());
                    SelectGroupName(_configRepository.SelectedGroup);
                    break;

                case ItemType.Script:
                    GroupBoxOnDeletingScript(this, _currentGroupBox.TabText);
                    break;
            }
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastUsedGroupAndScript();

            if (ModifierKeys == Keys.Control)
            {
                SaveCurrentGroup();
            }
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

            PublishResults(null);
            ShowProgressBar();
            cts = new CancellationTokenSource();
            var script = _currentGroupBox.HasSelectedText ? _currentGroupBox.SelectedText : _currentGroupBox.Text;
            var runner = new SqlRunner(script, cts.Token);
            await runner
                .GetDataSet(SelectedConnectionString)
                .ContinueWith(r =>
                {
                    if (r.Result?.Results?.Tables.Count > 0)
                    {
                        resultsBox.BeginInvoke(new Action<DataSet>(PublishResults), r.Result?.Results);
                    }
                    else
                    {
                        resultsBox.BeginInvoke(new Action<string>(ShowResultMessage), r.Result?.Messages);
                    }

                    this.BeginInvoke(new Action<DataTableCollection, DateTime>(QueryFinished), r.Result?.Results?.Tables, startedAt);
                });
        }

        private void QueryFinished(DataTableCollection tables, DateTime startedAt)
        {
            HideProgressBar();

            runButton.Tag = string.Empty;
            runButton.Text = "Run";
            runButton.BackColor = Color.YellowGreen;

            if (tables != null)
            {
                resultsLabel.Text = "Results: " + string.Join("/", tables
                    .Cast<DataTable>()
                    .Where(t => t.Rows.Count > 0)
                    .Select(t => t.Rows.Count)
                );
            }

            startLabel.Text = $"Elapsed time: {(DateTime.Now - startedAt):g}";
            SelectedScript.ConnectionString = SelectedConnectionStringName;
            _storageRepository.UpdateScriptInMetadata(SelectedGroupName, SelectedScript);
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_currentItemType == ItemType.Group)
                {
                    if (SelectedGroupName == NewGroupName)
                    {
                        SelectGroupName(_configRepository.SelectedGroup);
                    }
                }

                _currentGroupBox.SetFocus();
            }

            if (e.KeyCode == Keys.F5)
            {
                runButton_Click(sender, e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveCurrentGroup();
                return; // skip "falsefication"
            }
        }

        private void generateInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = CsvFileReader.Load(openFileDialog1.FileName);
                _currentGroupBox.AppendTextToCurrentTab(SqlGenerator.GenerateSelectIntoTemp(dt));
            }
        }

        private void generateFromValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var dt = CsvFileReader.Load(openFileDialog1.FileName);
                _currentGroupBox.AppendTextToCurrentTab(SqlGenerator.GenerateSelectFromValues(dt));
            }
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

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentGroup();
        }


        //private void MakeComboboxReadOnly(object sender, KeyPressEventArgs e)
        //{
        //    // Doesn't allow to edit and at the same time allows my emulated double click
        //    e.Handled = true;
        //}

        #endregion

        #endregion

        private void groupNamesComboBox_Enter(object sender, EventArgs e)
        {
            ConfigureNameEditing(SelectedGroupName, ItemType.Group);
        }

        private void connStrComboBox_Enter(object sender, EventArgs e)
        {
            ConfigureNameEditing(SelectedConnectionStringName, ItemType.ConnectionStringName);
        }

        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(sender, null);
            }
        }

        private void valueTextBox_Enter(object sender, EventArgs e)
        {
            if (_currentItemType == ItemType.ConnectionStringName)
                _currentItemType = ItemType.ConnectionString;
        }
    }
}
