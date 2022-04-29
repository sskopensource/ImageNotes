using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Common
{
    public class MainGrid:Grid
    {
        public MainGrid()
        {
            this.ShowGridLines=true;
        }

        public void SetControlPanel(Canvas child)
        {
            SetColumn(child, 1);
            SetRow(child, 1);
        }
        public void SetLabelRegion(Canvas child)
        {
            SetColumn(child, 0);
            SetRow(child, 1);
        }
        public void SetNavBar(Canvas child)
        {
            SetColumn(child, 0);
            SetRow(child, 0);
            SetRowSpan(child, 2);
        }
    }
}
