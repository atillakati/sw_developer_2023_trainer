using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arithmetische Operatoren
            //+ - / * %

            double flacheRechteck = 0.0;
            double seiteA = 0.0;
            double seiteB = 0.0;

            flacheRechteck = (seiteA + seiteB) * 2;

            //Zusammengesetzte Operatoren
            seiteA = 5.0;

            seiteA = seiteA + 3;
            seiteA += 3;
            seiteA -= 2;
            seiteA *= 5;
            seiteA /= 3;

            //Inkrement / Dekrement
            seiteA = seiteA + 1;
            seiteA += 1;
            seiteA++;  // ==> (Post) Inkrement
            seiteA--;  // ==> (Post) Dekrement
             
            //Pre- & Post-Inkrement
            seiteA = 3;
            Console.WriteLine($"Seite a: {seiteA++}");
            Console.WriteLine($"Seite a: {seiteA}");

            //Vergleichsoperatoren
            // < > <= >= == !=
            Console.WriteLine($"Ergebnis: {seiteA > 5.0}");

            string name = "Gandalf";
            Console.WriteLine($"Ist Alf: {name.Contains("alf")}");

            //Logischen Operatoren
            // & | !  && || 
        }
    }
}

