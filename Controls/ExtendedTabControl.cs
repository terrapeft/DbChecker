using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BackofficeTools.Controls
{
    public class ExtendedTabControl : TabControl
    {
        /*
         https://stackoverflow.com/questions/3183352/close-button-in-tabcontrol
         https://social.technet.microsoft.com/wiki/contents/articles/50957.c-winform-tabcontrol-with-add-and-close-button.aspx
         https://overcoder.net/q/871842/как-усечь-строку-чтобы-уместиться-в-контейнере
        */
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 10;

        private void tabControl1_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (TabPages[e.Index].Name != "tabPagePlus")
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            }

            e.Graphics.DrawString(TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        public ExtendedTabControl()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            //SizeMode = TabSizeMode.Fixed;
            //ItemSize = new Size(70, 18);
        }


    }
}
