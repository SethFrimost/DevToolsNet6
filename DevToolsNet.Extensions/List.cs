using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Extensions
{
    public static class List
    {
        /// <summary xml:lang="es">
        /// Concatena los textos dentro de la colección, separando los items por líneas
        /// </summary>
        /// <param name="x"></param>
        /// <returns>string concatenado</returns>
        public static string ConcatText(this List<string> x)
        {
            StringBuilder sb = new StringBuilder();

            x.ForEach(a => sb.AppendLine(a));

            if (x != null)
            {
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary xml:lang="es">
        /// Concatena los textos dentro de la colección, separando los items por líneas.
        /// Los mensajes iguales no se repiten
        /// </summary>
        /// <param name="x">List&gt;string&lt;</param>
        /// <returns>string concatenado</returns>
        public static string ConcatTextDistint(this List<string> x)
        {
            StringBuilder sb = new StringBuilder();

            if (x != null)
            {
                foreach (string s in x.Distinct())
                {
                    sb.AppendLine(s);
                }
            }

            return sb.ToString();
        }


        /// <summary xml:lang="es">
        /// Concatena los textos dentro de la colección, separando los items por líneas.
        /// Los mensajes iguales no se repiten
        /// </summary>
        /// <param name="x">List&gt;string&lt;</param>
        /// <param name="nodeTag">nombre para los diferentes elementos del xml</param>
        /// <returns>string concatenado</returns>
        public static string ConcatTextDistintXML(this List<string> x, string nodeTag)
        {
            StringBuilder sb = new StringBuilder();

            if (x != null)
            {
                foreach (string s in x.Distinct())
                {
                    sb.AppendLine(string.Format("<{0}>{1}</{0}>", nodeTag, s));
                }
            }

            //sb.AppendLine(string.Format("</{0}>", rootNode));

            return sb.ToString();
        }

    }
}
