using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>Comprueba si una fecha esta entre otras</summary>
        /// <param name="input">fecha a comprobar</param>
        /// <param name="desde">fecha minima</param>
        /// <param name="hasta">fecha maxima</param>
        /// <param name="inclusive">Inluir fechas en la comparacion</param>
        /// <returns></returns>
        public static bool Between(this DateTime input, DateTime desde, DateTime hasta, bool inclusive = true)
        {
            if (inclusive)
            {
                return (input >= desde && input <= hasta);
            }
            else
            {
                return (input > desde && input < hasta);
            }
        }
    }
}
