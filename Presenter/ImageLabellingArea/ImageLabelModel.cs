using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLabellingArea
{

    class ImageLabelModel
    {
        public ImageLabelModel()
        {
            //Subscribe to Active label change callback
            LabellingResources.ActiveLabel.Subscribe(OnActiveLabelChanged);
        }

        private void OnActiveLabelChanged()
        {
            Console.WriteLine("Label Changed");
        }
    }
}
