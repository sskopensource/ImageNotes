using MainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageLabellingArea;
using System.Windows;
using System.Threading;
using Labelling;

namespace Platform
{
    public class Launcher
    {
        public static MainWindowController mainWindow;
        public static ImageLabelRegionController region;
        public static LabellingManager labellingMgr;

        public static void LoadComponet()
        {
            //Load main component
            mainWindow = new MainWindowController();
            //Load labelRegion
            region = new ImageLabelRegionController(mainWindow.GetGridView());
            //Show main window

            labellingMgr = new LabellingManager();
            mainWindow.GetView().ShowDialog();
        }
    }
}
