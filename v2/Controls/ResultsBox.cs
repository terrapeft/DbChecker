using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DbChecker.Controls
{
    public partial class ResultsBox : UserControl
    {
        private DataSet _tables;

        public DataSet Dataset
        {
            set
            {
                _tables = value;
                int k = 1;
                tabControl1.TabPages.Clear();
                foreach (DataTable dt in _tables.Tables)
                {
                    var p = new TabPage($"Results {k++}");
                    p.Controls.Add(GetGridView(dt));
                    p.Tag = dt;
                    tabControl1.TabPages.Add(p);
                }
            }
        }

        public DataObject SelectedResult
        {
            get
            {
                if (tabControl1.SelectedTab.Controls.Count > 0)
                {
                    var grid = tabControl1.SelectedTab.Controls[0] as DataGridView;
                    if (grid != null)
                    {
                        grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        grid.RowHeadersVisible = true;
                        grid.SelectAll();
                    }
                    return grid?.GetClipboardContent();
                }

                return null;
            }
        }

        public IEnumerable<DataObject> Results
        {
            get
            {
                var objs = new List<DataObject>();

                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (page.Controls.Count > 0)
                    {
                        if (page.Controls[0] is DataGridView grid)
                        {
                            grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                            grid.RowHeadersVisible = true;
                            grid.SelectAll();

                            objs.Add(grid.GetClipboardContent());
                        }
                    }
                }

                return objs;
            }
        }

        public string Messages
        {
            set
            {
                tabControl1.TabPages.Clear();
                var p = new TabPage("Messages");
                p.Controls.Add(GetTextBox(value));
                tabControl1.TabPages.Add(p);
            }
        }

        private Control GetTextBox(string str)
        {
            var tb = new TextBox();
            tb.Multiline = true;
            tb.Dock = DockStyle.Fill;
            tb.Text = str;
            return tb;
        }

        private Control GetGridView(DataTable dt)
        {
            var gv = new DataGridView();
            gv.Dock = DockStyle.Fill;
            gv.DataSource = dt;
            return gv;
        }

        public ResultsBox()
        {
            InitializeComponent();
        }
    }
}
