using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiEnums
{
    public enum LabelState
    {
        Select,
        Anchor,
        Drag,
        Move,
        None
    }

    public enum DirtyFlag
    {
        None,
        Refresh,
        RefreshAll,
        Update
    }
}
