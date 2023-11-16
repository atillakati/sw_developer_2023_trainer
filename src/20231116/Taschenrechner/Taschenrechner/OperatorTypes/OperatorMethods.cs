using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.OperatorTypes
{
    internal abstract class OperatorMethods
    {
        public static double Addition(double val1, double val2)
        {
            return val1 + val2;
        }

        public static double Substration(double val1, double val2)
        {
            return val1 - val2;
        }

        public static double Multiplication(double val1, double val2)
        {
            return val1 * val2;
        }

        public static double Division(double val1, double val2)
        {
            if(val2 == 0)
            {
                return double.PositiveInfinity;
            }

            return val1 / val2;
        }
    }
}
