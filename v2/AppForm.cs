using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbChecker.Models;
using DbChecker.Repositories;
using DbChecker.Views;

namespace DbChecker
{
    public partial class AppForm : Form
    {
        private ISqlRepository _sqlRepository;
        private IConfigRepository _configRepository;
        private GroupsView _groupsView;
        private GroupResultsCollection _groupResults;
        private List<Group> _groups;
        private UIBox _uiBox;

        public AppForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _sqlRepository = new SqlRepository();

            _groups = _sqlRepository.GetSql();
            _groupResults = new GroupResultsCollection(_groups);

            _groupsView = new GroupsView();
            groundSplitContainer.Panel2.Controls.Clear();
            groundSplitContainer.Panel2.Controls.Add(_groupsView.CurrentView);

            _groupsView.SelectedGroupChanged += (sender, s) =>
            {
                _uiBox = new UIBox(_groupResults.Results.FirstOrDefault(g => g.GroupName.Equals(s)));
                var btn = new CloseButton().SetPosition(queryAndResultsSplitContainer.Panel1);

                queryAndResultsSplitContainer.Panel1.Controls.Clear();
                queryAndResultsSplitContainer.Panel1.Controls.Add(_uiBox.CreateBox());

                queryAndResultsSplitContainer.Panel1.Controls.Add(btn);
                btn.BringToFront();
            };

            _groupsView.Bind(_groups);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_uiBox != null)
            {
                _sqlRepository.PatchAndSave(_uiBox.GetModel());
            }
        }
    }
}
