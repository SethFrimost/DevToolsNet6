using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Generics.ObjectMerge
{
    public class ObjectMerger<T> where T : new()
    {
        public MergeOptions mergeOptions { get; private set; }

        T ObjX;
        T ObjY;
        List<PropMerge> properties = null;
        Type tipo;
        PropertyInfo[] props;

        public ObjectMerger()
        {
            tipo = typeof(T);
            props = tipo.GetProperties();
        }

        public ObjectMerger(T objX, T objY) : this()
        {
            ObjX = objX;
            ObjY = objY;
        }


        public List<PropMerge> Compare(T objX, T objY)
        {
            ObjX = objX;
            ObjY = objY;

            return Compare();
        }

        public List<PropMerge> Compare()
        {
            properties = new List<PropMerge>();
            foreach (var p in props)
            {
                var pm = new PropMerge(p, p.GetValue(ObjX), p.GetValue(ObjY));

                if (mergeOptions.ValueOverNull)
                {
                    if (pm.ValueX == null && pm.ValueY != null) pm.Selection = PropMergeSelection.Y;
                    else if (pm.ValueX != null && pm.ValueY == null) pm.Selection = PropMergeSelection.X;
                }

                properties.Add(pm);
            }

            return properties;
        }

        public T MergeObjects()
        {
            T res = new T();
            foreach (var p in properties) 
            {
                p.PropertyInfo.SetValue(res, p.ValueResult);
            }
            return res;
        }
    }
}
