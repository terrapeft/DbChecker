using System.Drawing;
using System.Windows.Forms;

namespace DbChecker.Controls
{
    public class CloseButton : Button
    {
        public CloseButton()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Name = "closeButton";
            Size = new Size(20, 19);
            Text = "x";
            UseVisualStyleBackColor = true;
        }

        public Button SetPosition(Control container)
        {
            Location = new Point(container.Width - 22, 1);
            return this;
        }
    }
}
