using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MainWindow
{
    public class MainWindowView:MainWindowUi
    {
        

        public TextBox label;

        public MainWindowView()
        {
            label = new TextBox();
            label.MinWidth = 20;
            label.Height = 40;
            label.FontSize = 30;
            Thickness x = new Thickness() { Left = 20, Top = 20 };
            label.Margin = x;
            labelRegion.Children.Add(label);
            this.labelRegion.Background = Brushes.Yellow;
            this.WindowState = WindowState.Maximized;
            ShowDialog();
        }
    }
}
