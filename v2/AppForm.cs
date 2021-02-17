using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbChecker.Controls;
using DbChecker.Models;
using DbChecker.Repositories;
using DbChecker.Views;

namespace DbChecker
{
    public partial class AppForm : Form
    {
        private ISqlRepository _sqlRepository;
        private IConfigRepository _configRepository;
        private GroupResultsCollection _groupResults;
        private List<Group> _groups;
        private QueryBox _uiBox;

        public AppForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _sqlRepository = new SqlRepository();

            AddConnectionStrings();

            _groups = _sqlRepository.GetSql();
            //_groupResults = new GroupResultsCollection(_groups);

            groupsControl.SelectedGroupChanged += (sender, g) =>
            {
                _uiBox = new QueryBox(g);
                var btn = new CloseButton().SetPosition(queryAndResultsSplitContainer.Panel1);

                queryAndResultsSplitContainer.Panel1.Controls.Clear();
                queryAndResultsSplitContainer.Panel1.Controls.Add(_uiBox.CreateBox());

                queryAndResultsSplitContainer.Panel1.Controls.Add(btn);
                btn.BringToFront();
            };

            groupsControl.Bind(_groups);

        }

        private void AddConnectionStrings()
        {
            connStrComboBox.Items.Clear();
            ConfigurationManager.RefreshSection("connectionStrings");

            connStrComboBox.Items.AddRange(_configRepository.ConnectionStrings);
            connStrComboBox.DisplayMember = "Name";
            connStrComboBox.Focus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_uiBox != null)
            {
                _sqlRepository.PatchAndSave(_uiBox.GetModel());
            }
        }

        private void connStrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connStrTextBox.Text = ((ConnectionStringSettings)connStrComboBox.SelectedItem).ConnectionString;
        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            var runner = new SqlRunner(_uiBox.Script);
            await runner.GetDataSet(connStrTextBox.Text).ContinueWith(r =>
            {
                if (r.Result?.Results?.Tables.Count > 0)
                {
                    resultsBox.BeginInvoke(new Action<DataSet>(SetTables), r.Result?.Results);
                }
                else
                {
                    resultsBox.BeginInvoke(new Action<string>(SetText), r.Result?.Messages);
                }
            });
        }

        private void SetTables(DataSet dataSet)
        {
            resultsBox.Tables = dataSet;
        }

        private void SetText(string text)
        {
            resultsBox.Messages = text;
        }

        private void recycleButton_Click(object sender, EventArgs e)
        {
            _groups = _sqlRepository.GetSql();
            _groupResults = new GroupResultsCollection(_groups);
        }
    }
}
