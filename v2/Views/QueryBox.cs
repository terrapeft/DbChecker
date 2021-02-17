using System.Linq;
using System.Windows.Forms;
using DbChecker.Models;
using FastColoredTextBoxNS;

//using Form = DbChecker.Global;

namespace DbChecker.Views
{
    public class QueryBox
    {
        private static int _tabPageCount;
        private static int _queryCount;

        private Group _group;
        private TabControl _groupTabControl;

        private TabPage Page => _groupTabControl.SelectedTab;

        public Script Script => _groupTabControl.SelectedTab.Tag as Script;

        public QueryBox(Group groupResults)
        {
            _group = groupResults;
        }

        public TabControl CreateBox()
        {
            _groupTabControl = new TabControl();
            _groupTabControl.Dock = DockStyle.Fill;
            _groupTabControl.Name = "groupsTabControl";

            foreach (var script in _group.Scripts)
            {
                _groupTabControl.Controls.Add(CreateTabPage(_groupTabControl, script));
            }

            CreatePlusTabPage(_groupTabControl);

            return _groupTabControl;
        }

        /// <summary>
        /// Save results from controls into model.
        /// </summary>
        public Group GetModel()
        {
            foreach (TabPage page in _groupTabControl.TabPages)
            {
                if (page.Tag is Script script)
                {
                    var textBox = page.Controls.Find(script.Name, false).FirstOrDefault() as FastColoredTextBox;
                    script.Text = textBox.Text;
                }
            }

            return _group;
        }

        private TabPage CreateTabPage(TabControl tabControl, Script script)
        {
            var tabPage = new TabPage();

            tabPage.Name = "tabPage" + ++_tabPageCount;
            tabPage.TabIndex = _tabPageCount;
            tabPage.Text = script.Name;
            tabPage.Tag = script;

            tabPage.DoubleClick += (sender, args) => { tabControl.Controls.RemoveByKey(tabPage.Name); };

            tabPage.Controls.Add(CreateQueryBox(script.Name, script.Text));

            return tabPage;
        }


        private TabPage CreatePlusTabPage(TabControl tabControl)
        {
            var plusTabPage = new TabPage();

            plusTabPage.Name = "tabPagePlus";
            plusTabPage.Text = "    +";

            plusTabPage.Enter += (o, e) =>
            {
                var name = "Script " + ++_queryCount;
                var script = new Script {Name = name};
                _group.Scripts.Add(script);

                var newTab = CreateTabPage(tabControl, script);
                tabControl.Controls.RemoveByKey(plusTabPage.Name);
                tabControl.Controls.Add(newTab);
                tabControl.Controls.Add(plusTabPage);
                tabControl.SelectTab(newTab);
            };

            //tabControl.Controls.RemoveByKey(tabPage.Name);
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
            if (sender is FastColoredTextBox qBox) Script.Text = qBox.Text;

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
