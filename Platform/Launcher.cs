using MainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class Launcher
    {
        public static MainWindowController mainWindow;
        public static void LoadComponet()
        {
            //Load main component
             mainWindow = new MainWindowController();
        }
    }
}
