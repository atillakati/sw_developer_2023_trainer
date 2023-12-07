using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double einWert = 5.96548;            

            //Console.WriteLine($"Der Artikel kostet: EUR {einWert:F2}");

            Console.WriteLine($"Der Artikel kostet: {einWert.ToCurrency()}");
        }        
    }
}
