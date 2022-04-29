using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace MainWindow
{
    public class MainWindowController
    {
        private MainWindowView view;
        public MainWindowController()
        {
            view = new MainWindowView();
        }

        public MainGrid GetGridView()
        {
            return view.mainGrid;
        }

        public MainWindowView GetView()
        {
            return view;
        }

    }
}
