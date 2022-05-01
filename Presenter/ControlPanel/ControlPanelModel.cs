using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiEnums;

namespace ControlPanel
{
    public class ControlPanelModel:ModelBase
    {
        private string m_txtBoxText;

        public ControlPanelModel()
        {
            m_txtBoxText = "";
            //Subscribe to Active label change callback
            LabellingResources.ActiveLabel.SubscribeReader(OnActiveLabelChanged);
        }

        private void OnActiveLabelChanged()
        {
            var curLabel = LabellingResources.ActiveLabel.GetActiveLabelText();
            if (SetAndNotifyIfDifferent(ref m_txtBoxText, curLabel))
            {
                SetDirtyFlag(DirtyFlag.Refresh);
            }
        }

        public string GetTextBoxText()
        {
            return m_txtBoxText;
        }
    }
}
