using System;
using System.Linq;
using System.Windows.Forms;
using DbChecker.Models;
using DbChecker.Repositories;
using FastColoredTextBoxNS;

//using Form = DbChecker.Global;

namespace DbChecker.Views
{
    public class QueryBox
    {
        private static int _tabPageCount;
        private static int _queryCount;

        private const string PlusTabPageName = "    +";
        private const string ScriptName = "Script ";

        private bool _initializing = false;
        private readonly Group _group;
        private readonly IConfigRepository _configRepository;
        private readonly IStorageRepository _storageRepository;
        private TabControl _groupTabControl;

        public TabPage Page => _groupTabControl.SelectedTab;

        public FastColoredTextBox TextBox => _groupTabControl.SelectedTab?.Controls[0] as FastColoredTextBox;

        public Group Group => _group;

        public Script Script
        {
            get
            {
                UpdateModel();
                return _groupTabControl.SelectedTab?.Tag as Script;
            }
        }

        public bool HasTextSelection => TextBox?.SelectedText.Length > 0;

        public Script TextSelection => new Script {Text = TextBox.SelectedText, Name = "Selection", Guid = Guid.Empty};

        public event EventHandler<Script> RenamingScript;
        public event EventHandler<Script> DeletingScript;

        public QueryBox(Group groupResults)
        {
            _group = groupResults;
            _configRepository = new ConfigRepository();
            _storageRepository = new SqlRepository();
        }
        public void SetTextForCurrentTab(string text)
        {
            if (Page.Controls[0] is FastColoredTextBox box)
            {
                box.Text = text;
            }
        }

        public TabControl CreateBox()
        {
            _initializing = true;

            _queryCount = _storageRepository.GetScriptNameIndex(_group.Name, ScriptName);
            _queryCount--;

            try
            {
                _groupTabControl = new TabControl();
                _groupTabControl.Dock = DockStyle.Fill;
                _groupTabControl.Name = "groupsTabControl";

                _groupTabControl.MouseClick += (o, e) =>
                {
                    if (!(o is TabControl tc)) return;
                    for (var i = 0; i < tc.TabCount; ++i)
                    {
                        if (tc.GetTabRect(i).Contains(e.Location))
                        {
                            var tp = tc.TabPages[i];
                            if (tp.Text == PlusTabPageName)
                            {
                                var name = "Script " + ++_queryCount;
                                var script = new Script { Name = name };
                                _group.Scripts.Add(script);

                                var newTab = CreateTabPage(_groupTabControl, script);
                                _groupTabControl.Controls.RemoveByKey(tp.Name);
                                _groupTabControl.Controls.Add(newTab);
                                _groupTabControl.Controls.Add(tp);
                                _groupTabControl.SelectTab(newTab);

                                RenamingScript?.Invoke(this, newTab.Tag as Script);
                            }
                        }
                    }
                };

                _groupTabControl.MouseDoubleClick += GroupTabControlOnMouseDoubleClick;

                foreach (var script in _group.Scripts)
                {
                    _groupTabControl.Controls.Add(CreateTabPage(_groupTabControl, script));
                }

                CreatePlusTabPage(_groupTabControl);

                _groupTabControl.SelectedTab = _groupTabControl.TabPages
                    .Cast<TabPage>()
                    .FirstOrDefault(p => p.Text == _configRepository.SelectedScript);

                return _groupTabControl;
            }
            finally
            {
                _initializing = false;
            }
        }

        private void GroupTabControlOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(sender is TabControl tc)) return;
            for (var i = 0; i < tc.TabCount; ++i)
            {
                if (tc.GetTabRect(i).Contains(e.Location))
                {
                    var tp = tc.TabPages[i];
                    if (tp.Text != PlusTabPageName)
                    {
                        RenamingScript?.Invoke(this, tp.Tag as Script);
                    }
                }
            }
        }

        /// <summary>
        /// Save results from controls into model.
        /// </summary>
        public Group GetModel()
        {
            UpdateModel();
            return _group;
        }


        public void UpdateModel()
        {
            foreach (TabPage page in _groupTabControl.TabPages)
            {
                if (page.Tag is Script script)
                {
                    var textBox = page.Controls[0] as FastColoredTextBox;
                    script.Text = textBox.Text;
                }
            }
        }

        private TabPage CreateTabPage(TabControl tabControl, Script script)
        {
            var tabPage = new TabPage();
            var menuItem = new MenuItem("Delete Tab");

            menuItem.Click += (sender, args) =>
            {
                DeletingScript?.Invoke(this, script);
            };

            tabPage.Name = "tabPage" + ++_tabPageCount;
            tabPage.TabIndex = _tabPageCount;
            tabPage.Text = script.Name;
            tabPage.Tag = script;
            tabPage.ContextMenu = new ContextMenu(new[] { menuItem } );
            tabPage.Controls.Add(CreateQueryBox(script.Name, script.Text));

            return tabPage;
        }


        private TabPage CreatePlusTabPage(TabControl tabControl)
        {
            var plusTabPage = new TabPage();

            plusTabPage.Name = "tabPagePlus";
            plusTabPage.Text = PlusTabPageName;

            tabControl.Controls.Add(plusTabPage);

            return plusTabPage;
        }


        private FastColoredTextBox CreateQueryBox(string textBoxName, string query = "")
        {
            var qBox = new FastColoredTextBox();
            qBox.Dock = DockStyle.Fill;
            qBox.Language = Language.SQL;
            qBox.Name = textBoxName;
            qBox.SelectionChangedDelayedEnabled = false;
            qBox.Text = query;

            qBox.TextChangedDelayed += qBox_TextChangedDelayed;
            qBox.KeyUp += qBox_KeyUp;

            return qBox;
        }

        private void qBox_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #region Common handlers
        private void qBox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            //if (sender is FastColoredTextBox qBox) Script.Text = qBox.Text;

            //if (sender is FastColoredTextBox qBox)
            //{
            //    var formatter = new FastColoredTextBox {Text = historyList[historyPosition]};

            //    if (qBox.Text != formatter.Text)
            //    {
            //        Global.Form.Text = Global.Form.Text.Trim('*') + "*";
            //    }
            //    else
            //    {
            //        Global.Form.Text = Global.Form.Text.Trim('*');
            //    }
            //}
        }
        #endregion

    }
}
