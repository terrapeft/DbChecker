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
using GroupBox = DbChecker.Views.GroupBox;

namespace DbChecker
{
    public partial class MainWindow : Form
    {
        public const string NewGroupName = "<Add new group>";

        private readonly IStorageRepository _storageRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IFileRepository _fileRepository;

        private ItemType _currentItemType;
        private string _currentItemOriginalValue;
        private DateTime _prevClick;
        private GroupBox _currentGroupBox;
        private CancellationTokenSource cts;
        //private List<Group> _groups;

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

        public string SelectedScriptSource => _currentGroupBox.Text;


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
            SelectGroupName(_configRepository.SelectedGroup);
        }

        #region Private methods

        private void StartRenaming(string text, ItemType type)
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

        private void SetTables(DataSet dataSet)
        {
            resultsBox.Dataset = dataSet;
        }

        private void SetText(string text)
        {
            resultsBox.Messages = text;
        }

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

            queryAndResultsSplitContainer.Panel1.Controls.Clear();
            queryAndResultsSplitContainer.Panel1.Controls.Add(_currentGroupBox.CreateBox(group));
        }

        #endregion

        #region Connection strings

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

        private void SelectConnectionString(string name)
        {
            connStrComboBox.SelectedIndex = connStrComboBox.FindStringExact(name);
        }

        #endregion

        #region Event handlers

        private void GroupBoxOnDeletingScript(object sender, string e)
        {
        }

        private void GroupBoxOnRenamingScript(object sender, string e)
        {
            StartRenaming(e, ItemType.Script);
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartRenaming(SelectedConnectionString, ItemType.ConnectionString);
        }

        private void groupNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedGroupName == NewGroupName)
            {
                StartRenaming(SelectedGroupName, ItemType.Group);
            }
            else
            {
                LoadTabs(_storageRepository.ReadGroup(SelectedGroupName));
            }
        }

        private void groupNamesComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                StartRenaming(SelectedGroupName, ItemType.Group);
            }

            _prevClick = DateTime.Now;
        }

        private void connStrComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                StartRenaming(SelectedConnectionString, ItemType.ConnectionString);
            }

            _prevClick = DateTime.Now;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (_currentItemType)
            {
                case ItemType.ConnectionString:
                    var newName = SelectedConnectionStringName;
                    _configRepository.SaveConnectionString(newName, SelectedValue);
                    AddConnectionStrings();
                    SelectConnectionString(newName);
                    break;

                case ItemType.Group:
                    _storageRepository.CreateOrRenameGroup(SelectedValue, _currentItemOriginalValue);
                    AddGroupNames(_storageRepository.ReadGroupNames());
                    SelectGroupName(SelectedValue);
                    SelectConnectionString(SelectedConnectionString);
                    break;

                case ItemType.Script:
                    if (!HasSelectedGroup())
                    {
                        messageLabel.Text = "Choose group before saving.";
                        return;
                    }

                    _storageRepository.SaveScript(SelectedGroupName, new Script { Name = SelectedValue, Text = SelectedScriptSource });

                    //SelectConnectionString(SelectedConnectionString);
                    break;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedConnectionStringName))
            {
                _configRepository.SelectedConnectionString = SelectedConnectionStringName;
            }

            SaveLastUsedGroupAndScript();

            if (ModifierKeys != Keys.Control)
            {
                var group = _currentGroupBox.GetModel(SelectedGroupName);
                _storageRepository.SaveGroup(group);
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

            SetTables(null);
            //SetText();
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
                        resultsBox.BeginInvoke(new Action<DataSet>(SetTables), r.Result?.Results);
                    }
                    else
                    {
                        resultsBox.BeginInvoke(new Action<string>(SetText), r.Result?.Messages);
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
        }

        #endregion

        #endregion

    }
}
