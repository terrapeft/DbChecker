using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DbChecker.Models;

namespace DbChecker.Controls
{
    public partial class GroupsControl : UserControl
    {
        private Group _currentGroup;
        public event EventHandler<Group> SelectedGroupChanged;

        public GroupsControl()
        {
            InitializeComponent();
        }

        public void Bind(List<Group> groups)
        {
            foreach (var group in groups)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Guid";
                comboBox1.Items.Add(group);
            }
        }

        public Group CurrentGroup => _currentGroup;
        public Control CurrentView => comboBox1;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentGroup = comboBox1.SelectedItem as Group;
            SelectedGroupChanged?.Invoke(comboBox1, _currentGroup);
        }
    }
}
