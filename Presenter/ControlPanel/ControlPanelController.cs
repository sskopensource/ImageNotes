using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiEnums;

namespace ControlPanel
{
    public class ControlPanelController:ControllerBase
    {
        private ControlPanelModel m_model;
        private ControlPanelView m_view;

        public ControlPanelController(MainGrid parent)
        {
            m_model = new ControlPanelModel();
            m_view = new ControlPanelView(parent,m_model);
        }

        public override void Update()
        {
            if (m_model == null)
            {
                return;
            }
            //Infinitely running function
            if (m_model.GetDirtyFlag() == DirtyFlag.Refresh)
            {
                GetView().RefreshControl();
                GetModel().SetDirtyFlag(DirtyFlag.None);
            }
        }

        public ControlPanelView GetView()
        {
            return m_view;
        }

        public ControlPanelModel GetModel()
        {
            return m_model;
        }
    }
}
