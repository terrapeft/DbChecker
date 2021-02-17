using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DbChecker.Controls
{
    public partial class ResultsBox : UserControl
    {
        public DataSet Tables
        {
            //get;
            set
            {
                int k = 1;
                tabControl1.TabPages.Clear();
                foreach (DataTable dt in value.Tables)
                {
                    var p = new TabPage($"Results {k++}");
                    p.Controls.Add(GetGridView(dt));
                    tabControl1.TabPages.Add(p);
                }
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
