using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Generics.ObjectMerge
{
    public class MergeOptions
    {
        public bool ValueOverNull { get; set; } = false;
        public PropMergeSelection SelectOverNone { get; set; } = PropMergeSelection.None;
    }
}
