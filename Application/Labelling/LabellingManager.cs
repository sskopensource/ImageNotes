using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labelling
{
    public class LabellingManager
    {
        public LabellingManager()
        {
            LabellingResources.ActiveLabel.SubscribeWriter(HandleSetLabel);
        }

        private void HandleSetLabel(object value)
        {
            var label = value.ToString();
            Console.WriteLine("Handle: "+label);
            LabellingResources.ActiveLabel.PublishActiveLabelTextResource(label);
        }
    }
}
