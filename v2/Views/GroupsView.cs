using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DbChecker.Models;
using FastColoredTextBoxNS;

namespace DbChecker
{
    public class GroupsView
    {
        private string _currentGroupName;
        private ComboBox _listView;
        public event EventHandler<string> SelectedGroupChanged;

        public GroupsView()
        {
            _listView = new ComboBox();
            _listView.Size = new Size(190, 24);
            _listView.Location = new Point(0, 0);
            _listView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _listView.Name = "combobox1";
            _listView.SelectedIndexChanged += (sender, args) =>
            {
                _currentGroupName = _listView.SelectedItem as string;
                SelectedGroupChanged?.Invoke(_listView, _currentGroupName);
            };
        }

        public void Bind(List<Group> groups)
        {
            foreach (var group in groups)
            {
                _listView.Items.Add(group.Name);
            }
        }

        public string CurrentGroup => _currentGroupName;
        public Control CurrentView => _listView;
    }
}
