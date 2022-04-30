using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Include
{
    public class ResourceBase
    {
        public static event Action ResourceChanged;

        public static void PublishResources()
        {
            //Invoke event when Counter property is changed
            ResourceChanged?.Invoke();
        }

        public static bool SetAndNotifyIfDifferent(ref string source,string target)
        {
            if (source != target)
            {
                source = target;
                return true;
            }
            return false;
        }

        public static void Subscribe(Action fn)
        {
            ResourceChanged += fn;
        }

        public static void Unsubscribe(Action fn)
        {
            ResourceChanged -= fn;
        }
    }
}
