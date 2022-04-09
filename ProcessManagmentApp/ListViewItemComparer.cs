using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManagmentApp
{
    internal class ListViewItemComparer : IComparer
    {
        private int columnIndex;
        public int ColumnIndex
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }

        private SortOrder sortDirection;
        public SortOrder SortDirection {
            get { return sortDirection; }
            set { sortDirection = value; }
        }   
        public ListViewItemComparer()
        {
            this.sortDirection = SortOrder.None;
        }
        public int Compare(object x, object y)
        {
            ListViewItem listViewItemX = x as ListViewItem;
            ListViewItem listViewItemY = y as ListViewItem;
            int result;
            switch (columnIndex)
            {
                case 0:
                    result = string.Compare(listViewItemX.SubItems[columnIndex].Text, listViewItemY.SubItems[columnIndex].Text, false);
                    break;
                case 1:
                    int lengthX = listViewItemX.SubItems[columnIndex].Text.Length;
                    int lengthY = listViewItemY.SubItems[columnIndex].Text.Length;
                    double valueX = double.Parse(listViewItemX.SubItems[columnIndex].Text.Substring(0, lengthX - 2));
                    double valueY = double.Parse(listViewItemY.SubItems[columnIndex].Text.Substring(0, lengthY - 2));
                    result = valueX.CompareTo(valueY);
                    break;
                default:
                    result = string.Compare(listViewItemX.SubItems[columnIndex].Text, listViewItemY.SubItems[columnIndex].Text, false);
                    break;
            }

            if(SortDirection == SortOrder.Ascending)
            {
                return result;
            }
            return -result;
        }
    }
}
