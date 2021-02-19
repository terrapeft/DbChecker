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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SavingItem?.Invoke(this, Item);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletingItem?.Invoke(this, Item);
        }
    }
}
