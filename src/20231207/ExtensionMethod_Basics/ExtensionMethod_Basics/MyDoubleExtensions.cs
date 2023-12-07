using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod_Basics
{
    public static class MyDoubleExtensions
    {
        public static string ToCurrency(this double valueToConvert) 
        {
            return $"EUR {valueToConvert:F2}";
        }
    }
}
