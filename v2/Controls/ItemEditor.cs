using System;
using System.Windows.Forms;
using DbChecker.Models;

namespace DbChecker.Controls
{
    public partial class ItemEditor : UserControl
    {
        private EditableItem _item = new EditableItem();

        public event EventHandler<EditableItem> DeletingItem;
        public event EventHandler<EditableItem> SavingItem;

        public ItemEditor()
        {
            InitializeComponent();
        }

        public EditableItem Item
        {
            get
            {
                _item.Value = connStrTextBox.Text;
                return _item;
            }
            set
            {
                _item = value;
                connStrTextBox.Text = _item.Value;
            }
        }

        public void SetFocus()
        {
            connStrTextBox.Focus();
            connStrTextBox.SelectAll();
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            SavingItem?.Invoke(this, Item);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletingItem?.Invoke(this, Item);
        }

        private void connStrTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                saveButton_Click(sender, null);
                e.Handled = true;
            }
        }
    }
}
