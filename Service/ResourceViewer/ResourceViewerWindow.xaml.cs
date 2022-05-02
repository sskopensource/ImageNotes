using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ResourceViewer
{
    /// <summary>
    /// Interaction logic for ResourceViewerWindow.xaml
    /// </summary>
    public partial class ResourceViewerWindow : Window
    {
        public ResourceViewerWindow()
        {
            InitializeComponent();
            LabellingResources.ActiveLabel.SubscribeReader(OnActiveLabelTextChanged);
        }

        private void OnActiveLabelTextChanged()
        {
            var curText = LabellingResources.ActiveLabel.GetActiveLabelText();
            if (!this.Dispatcher.CheckAccess())
            {
                //If not in UI Thread
                this.Dispatcher.Invoke(() =>
                {
                    activelbl.Text = curText;
                });
            }
            else
            {
                activelbl.Text = curText;
            }
        }
    }
}
