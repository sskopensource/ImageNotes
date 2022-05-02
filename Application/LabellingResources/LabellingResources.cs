using Include;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabellingResources
{
    //Resource for Active Label
    public class ActiveLabel : ResourceBase
    {
        private static string p_activeLabelText;
        private static string h_activeLabelText;

        public static void SetActiveLabelText(string text)
        {
            if (SetAndNotifyIfDifferent(ref h_activeLabelText, text))
            {
                HandleResource(h_activeLabelText);
            }
        }

        public static void PublishActiveLabelTextResource(string text)
        {
            if (SetAndNotifyIfDifferent(ref p_activeLabelText, text))
            {
                h_activeLabelText = p_activeLabelText;
                PublishResources();
            }
        }

        public static string GetActiveLabelText()
        {
            return p_activeLabelText;
        }
    }
}
