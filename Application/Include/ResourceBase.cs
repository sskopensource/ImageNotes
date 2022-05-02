using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Include
{
    public class ResourceBase
    {
        protected static event Action ResourceChanged;
        public delegate void HandleEvent(object str);
        public static event HandleEvent Handle;
        
        protected static void HandleResource(object obj)
        {
            Handle?.Invoke(obj);
        }

        protected static void PublishResources()
        {
            ResourceChanged?.Invoke();
        }

        public static void SubscribeReader(Action fn)
        {
            ResourceChanged += fn;
        }

        public static void UnsubscribeReader(Action fn)
        {
            ResourceChanged -= fn;
        }

        public static void SubscribeWriter(HandleEvent fn)
        {
            Handle += fn;
        }

        public static void UnsubscribeWriter(HandleEvent fn)
        {
            Handle -= fn;
        }

        protected static bool SetAndNotifyIfDifferent(ref string source, string target)
        {
            if (source != target)
            {
                source = target;
                return true;
            }
            return false;
        }
    }
}
