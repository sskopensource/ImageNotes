using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiEnums;

namespace ImageLabellingArea
{
    public class ImageLabelControl:ControllerBase
    {
        public ImageLabel view;
        public ImageLabelModel model;
        public ImageLabelControl(ImageLabellingRegion parent)
        {
            model = new ImageLabelModel();
            view = new ImageLabel(parent,model);
        }

        public override void Update()
        {
            if (model == null)
            {
                return;
            }
            //Infinitely running function
            if (model.GetDirtyFlag()==DirtyFlag.Refresh)
            {
                GetView().RefreshLabel();
                GetModel().SetDirtyFlag(DirtyFlag.None);
            }

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
