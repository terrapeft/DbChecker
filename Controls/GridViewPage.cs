using System.Windows.Forms;

namespace BackofficeTools.Controls
{
    public class GridViewPage
    {
        public GridViewPage(string name, DataObject dataObject)
        {
            Name = name;
            DataObject = dataObject;
        }

        public string Name { get; set; }
        public DataObject DataObject { get; set; }
    }
}
