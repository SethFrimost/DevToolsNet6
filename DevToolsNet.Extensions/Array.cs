using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>Find all elements</summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Source array</param>
        /// <param name="match">Match predicate</param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match);
        }

        /// <summary>Find all elements and converto to List</summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Source array</param>
        /// <param name="match">Match predicate</param>
        /// <returns></returns>
        public static List<T> FindAllToList<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match).ToList<T>();
        }

        /// <summary>Append array into source array</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static T[] AppendArray<T>(this T[] x, T[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            int oldLen = x.Length;
            Array.Resize<T>(ref x, x.Length + y.Length);
            Array.Copy(y, 0, x, oldLen, y.Length);
            return x;
        }

    }
}
