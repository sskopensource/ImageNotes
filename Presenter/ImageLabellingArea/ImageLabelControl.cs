using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLabellingArea
{
    public class ImageLabelControl
    {
        public ImageLabel view;
        public ImageLabelModel model;
        public ImageLabelControl(ImageLabellingRegion parent)
        {
            model = new ImageLabelModel();
            view = new ImageLabel(parent);
        }

        public ImageLabel GetView()
        {
            return view;
        }

        public ImageLabelModel GetModel()
        {
            return model;
        }
    }
}
