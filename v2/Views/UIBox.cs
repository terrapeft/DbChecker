using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DbChecker.Models;
using FastColoredTextBoxNS;

//using Form = DbChecker.Global;

namespace DbChecker
{
    public class UIBox
    {
        private static int _tabPageCount;
        private static int _queryCount;

        private GroupResults _groupResults;
        private TabControl _groupTabControl;

        public UIBox(GroupResults groupResults)
        {
            _groupResults = groupResults;
        }

        public TabControl CreateBox()
        {
            _groupTabControl = new TabControl();
            _groupTabControl.Dock = DockStyle.Fill;
            _groupTabControl.Name = "groupsTabControl";

            foreach (var scriptResults in _groupResults.ScriptResults)
            {
                _groupTabControl.Controls.Add(CreateTabPage(_groupTabControl, scriptResults.Script.Name, scriptResults.Script.Text));
            }

            CreatePlusTabPage(_groupTabControl);

            return _groupTabControl;
        }

        /// <summary>
        /// Save results from controls into model.
        /// </summary>
        public GroupResults GetModel()
        {
            foreach (TabPage page in _groupTabControl.TabPages)
            {
                var script = _groupResults.ScriptResults.FirstOrDefault(sr => sr.Script.Name.Equals(page.Text))?.Script;
                if (script != null)
                {
                    var textBox = page.Controls.Find(script.Name, false).FirstOrDefault() as FastColoredTextBox;
                    script.Text = textBox.Text;
                }
            }

            return _groupResults;
        }

        private TabPage CreateTabPage(TabControl tabControl, string name, string query = "")
        {
            var tabPage = new TabPage();

            tabPage.Name = "tabPage" + ++_tabPageCount;
            tabPage.TabIndex = _tabPageCount;
            tabPage.Text = name;
            tabPage.DoubleClick += (sender, args) => { tabControl.Controls.RemoveByKey(tabPage.Name); };

            tabPage.Controls.Add(CreateQueryBox(name, query));

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
                var newTab = CreateTabPage(tabControl, name);
                tabControl.Controls.RemoveByKey(plusTabPage.Name);
                tabControl.Controls.Add(newTab);
                tabControl.Controls.Add(plusTabPage);
                tabControl.SelectTab(newTab);

                _groupResults.ScriptResults.Add(new ScriptResult(new Script {Name = name}));
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
