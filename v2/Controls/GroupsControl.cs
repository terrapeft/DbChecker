using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Forms;
using DbChecker.Models;

namespace DbChecker.Controls
{
    public partial class GroupsControl : UserControl
    {
        private static DateTime prevClick;
        private Group _currentGroup;
        public event EventHandler<Group> SelectedGroupChanged;
        public event EventHandler<Group> RenamingGroup;

        public GroupsControl()
        {
            InitializeComponent();
        }

        public void Bind(List<Group> groups)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = string.Empty;

            foreach (var group in groups)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Guid";
                comboBox1.Items.Add(group);
            }
        }

        public Group CurrentGroup => _currentGroup;

        public string CurrentValue => comboBox1.Text;

        public void SelectItem(string name)
        {
            comboBox1.SelectedIndex = comboBox1.FindStringExact(name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentGroup = comboBox1.SelectedItem as Group;
            SelectedGroupChanged?.Invoke(comboBox1, _currentGroup);
        }


        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < prevClick)
            {
                RenamingGroup?.Invoke(this, _currentGroup);
            }

            prevClick = DateTime.Now;
        }
    }
}
