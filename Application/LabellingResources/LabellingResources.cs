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
        private static string _activeLabelText;

        public static void SetActiveLabelText(string text)
        {
            if (SetAndNotifyIfDifferent(ref _activeLabelText, text))
            {
                PublishResources();
            }
        }

        public static string GetActiveLabelText()
        {
            return _activeLabelText;
        }
    }
}
