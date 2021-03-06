using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiEnums;

namespace ImageLabellingArea
{

    public class ImageLabelModel:ModelBase
    {
        private string m_labelText;
        public ImageLabelModel()
        {
            //Subscribe to Active label change callback
            LabellingResources.ActiveLabel.SubscribeReader(OnActiveLabelChanged);
        }

        private void OnActiveLabelChanged()
        {
            var curLabel = LabellingResources.ActiveLabel.GetActiveLabelText();
            if(SetAndNotifyIfDifferent(ref m_labelText, curLabel))
            {
                SetDirtyFlag(DirtyFlag.Refresh);
            }
        }

        public string GetLabelText()
        {
            return m_labelText;
        }
    }
}
