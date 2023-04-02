using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Generics.ObjectMerge
{
    public class PropMerge
    {
        public PropMerge(PropertyInfo propInfo, object? valueX, object? valueY) 
        {
            PropertyInfo = propInfo;
            ValueX = valueX;
            ValueY = valueY;
        }

        public PropMerge(PropertyInfo propInfo, object? valueX, object? valueY, MergeOptions mergeOptions) : this(propInfo,valueX,valueY)
        {
            mergeOptions = new MergeOptions();
        }

        MergeOptions? mergeOptions = null;
        public PropertyInfo PropertyInfo { get; private set; }
        public object? ValueX { get; private set; }
        public object? ValueY { get; private set; }
        public PropMergeSelection Selection { get; set; } = PropMergeSelection.None;

        public object? ValueResult
        {
            get
            {
                if (Selection == PropMergeSelection.X) return ValueX;
                else if (Selection == PropMergeSelection.Y) return ValueY;
                else
                { 
                    if(mergeOptions?.SelectOverNone == PropMergeSelection.X) return ValueX;
                    else if(mergeOptions?.SelectOverNone == PropMergeSelection.Y) return ValueY;
                    else return null;
                }
            }
        }

        public bool Equals()
        {
            return ValueX == ValueY;
        }
    }
}