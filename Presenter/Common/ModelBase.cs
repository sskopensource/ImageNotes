using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiEnums;

namespace Common
{
    public class ModelBase
    {
        private DirtyFlag m_dirtyFlag;

        public DirtyFlag GetDirtyFlag()
        {
            return m_dirtyFlag;
        }

        public void SetDirtyFlag(DirtyFlag flg)
        {
            m_dirtyFlag = flg;
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
