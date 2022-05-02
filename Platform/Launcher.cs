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
using ControlPanel;
using ResourceViewer;

namespace Platform
{
    public class Launcher
    {
        public static MainWindowController mainWindow;
        public static ImageLabelRegionController region;
        public static ControlPanelController controlPanel;
        public static LabellingManager labellingMgr;
        public static ResourceViewerWindow resViewer;

        // Make it true for showing resource viewer.
        private static bool showResourceViewer = false;

        public static void LoadComponet()
        {
            //Load main component
            mainWindow = new MainWindowController();
            //Load labelRegion
            region = new ImageLabelRegionController(mainWindow.GetGridView());

            //Load Control Panel
            controlPanel = new ControlPanelController(mainWindow.GetGridView());

            //Show main window

            labellingMgr = new LabellingManager();

            if (showResourceViewer)
            {
                Thread viewerThread = new Thread(delegate ()
                {
                    resViewer = new ResourceViewerWindow();
                    resViewer.Dispatcher.Invoke(new Action(delegate ()
                    {
                        resViewer.ShowDialog();
                    }));
                });

                viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                viewerThread.Start();
            }

            mainWindow.GetView().ShowDialog();
        }
    }
}
