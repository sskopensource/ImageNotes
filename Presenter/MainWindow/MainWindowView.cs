using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MainWindow
{
    public class MainWindowView:MainWindowUi
    {
        public TextBox label;
        public TextBlock label2;
        public MainWindowView()
        {
            ShowDialog();
        }
    }
}
