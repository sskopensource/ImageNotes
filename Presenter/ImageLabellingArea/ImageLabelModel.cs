using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLabellingArea
{

    public class ImageLabelModel
    {
        public ImageLabelModel()
        {
            //Subscribe to Active label change callback
            LabellingResources.ActiveLabel.SubscribeReader(OnActiveLabelChanged);
        }

        private void OnActiveLabelChanged()
        {
            Console.WriteLine("OnActiveLabelCanged: "+ LabellingResources.ActiveLabel.GetActiveLabelText());
        }
    }
}
