using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DbChecker.Models;
using DbChecker.Repositories;
using FastColoredTextBoxNS;
using Group = DbChecker.Models.Group;

namespace DbChecker.Views
{
    public class GroupBox
    {
        private static int _tabPageCount;

        private const string PlusTabPageName = "    +";
        private const string TabName = "Script";

        private bool _initializing = false;
        private readonly IConfigRepository _configRepository;
        private TabControl _groupTabControl;

        private FastColoredTextBox TextBox {
            get
            {
                if (_groupTabControl.SelectedTab?.Controls.Count > 0 &&
                    _groupTabControl.SelectedTab?.Controls[0] is FastColoredTextBox t)
                {
                    return t;
                }

                return null;
            }
        }

        public string TabText
        {
            get => _groupTabControl.SelectedTab.Text;
            set => _groupTabControl.SelectedTab.Text = value;
        }

        public string Text
        {
            get
            {
                if (_groupTabControl.SelectedTab?.Controls.Count > 0 && _groupTabControl.SelectedTab?.Controls[0] is FastColoredTextBox t)
                {
                    return t.Text;
                }

                return null;
            }
        }

        public bool WordWrap
        {
            get => TextBox.WordWrap;
            set => TextBox.WordWrap = value;
        }

        public string SelectedText => TextBox?.SelectedText;

        public bool HasSelectedText => TextBox?.SelectedText.Length > 0;

        public event EventHandler<string> RenamingScript;
        public event EventHandler<string> DeletingScript;

        public GroupBox()
        {
            _configRepository = new ConfigRepository();
        }

        public void AppendTextToCurrentTab(string text)
        {
            if (_groupTabControl.SelectedTab?.Controls.Count > 0 && _groupTabControl.SelectedTab.Controls[0] is FastColoredTextBox box)
            {
                box.AppendText($"{Environment.NewLine}");
                box.AppendText(text);
            }
        }

        public void RemoveSelectedTab()
        {
            _groupTabControl.TabPages.Remove(_groupTabControl.SelectedTab);
        }

        public void SetFocus()
        {
            TextBox?.Focus();
        }

        public TabControl CreateBox(Group group = null)
        {
            _initializing = true;

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
                                var name = $"{TabName} {GetNextIndex(GetTabNames(), TabName)}".Trim();

                                var newTab = CreateTabPage(_groupTabControl);
                                _groupTabControl.Controls.RemoveByKey(tp.Name);
                                _groupTabControl.Controls.Add(newTab);
                                _groupTabControl.Controls.Add(tp);
                                _groupTabControl.SelectTab(newTab);

                                RenamingScript?.Invoke(this, name);
                            }
                        }
                    }
                };

                _groupTabControl.MouseDoubleClick += GroupTabControlOnMouseDoubleClick;

                if (group != null)
                {
                    foreach (var script in group.Scripts)
                    {
                        _groupTabControl.Controls.Add(CreateTabPage(_groupTabControl, script.Name, script.Text));
                    }
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

        public Group GetModel(string groupName)
        {
            var group = new Group(groupName);

            foreach (TabPage page in _groupTabControl.TabPages)
            {
                if (page.Text != PlusTabPageName)
                {
                    var textBox = page.Controls[0] as FastColoredTextBox;
                    var script = new Script();
                    script.Text = textBox.Text;
                    script.Name = page.Text;
                    group.Scripts.Add(script);
                }
            }

            return group;
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
                        RenamingScript?.Invoke(this, tp.Text);
                    }
                }
            }
        }

        private TabPage CreateTabPage(TabControl tabControl, string name = null, string text = null)
        {
            var tabPage = new TabPage();
            var menuItem = new MenuItem("Delete Tab");

            menuItem.Click += (sender, args) =>
            {
                DeletingScript?.Invoke(this, name);
            };

            tabPage.Name = "tabPage" + ++_tabPageCount;
            tabPage.TabIndex = _tabPageCount;
            tabPage.Text = (name ?? $"{TabName} {GetNextIndex(GetTabNames(), TabName)}").Trim();
            tabPage.ContextMenu = new ContextMenu(new[] { menuItem } );
            tabPage.Controls.Add(CreateTextBox(text));

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

        private FastColoredTextBox CreateTextBox(string query = "")
        {
            var qBox = new FastColoredTextBox();
            qBox.Dock = DockStyle.Fill;
            qBox.Language = Language.SQL;
            //qBox.Name = textBoxName;
            qBox.SelectionChangedDelayedEnabled = false;
            qBox.Text = query;

            return qBox;
        }

        private string[] GetTabNames()
        {
            return _groupTabControl.TabPages
                .Cast<TabPage>()
                .Select(p => p.Text)
                .ToArray();
        }

        private string GetNextIndex(string[] names, string name)
        {
            if (!names.Any())
            {
                return string.Empty;
            }

            var matches = new List<int>();

            if (names.Any(n => n.Equals(name)))
            {
                matches.Add(0);
            }

            foreach (var f in names)
            {
                var reg = new Regex($@"(?<name>{name}) (?<index>\d+)*");
                var match = reg.Match(f);
                if (match.Success)
                {
                    if (match.Groups["name"].Success && match.Groups["index"].Success)
                    {
                        matches.Add(Convert.ToInt32(match.Groups["index"].Value));
                    }
                }
            }

            var res = matches.Any()
                ? (matches.Max() + 1).ToString()
                : string.Empty;

            return res;
        }
    }
}
