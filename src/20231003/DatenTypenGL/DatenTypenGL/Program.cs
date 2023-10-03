using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenTypenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl;   // ==> Deklaration
            zahl = 10;  // ==> Initialisierung

            int counter = 3;  // ==> Deklaration & Initialisierung
                               
            Console.WriteLine(zahl);
            Console.WriteLine(counter);
            Console.WriteLine("Counter: " + counter + " Max: " + int.MaxValue + " Min: " + int.MinValue);

            bool isPowerOn = false;

            Console.WriteLine("Power State: " + isPowerOn);
            Console.WriteLine($"Power State: {isPowerOn} {counter} {zahl}");

            string name = "Gandalf";
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Länge: {name.Length} Zeichen");
            counter = name.Length + 5;

            Console.WriteLine();

            name = "";
            name = string.Empty;

            double weight = 15.856;
            Console.WriteLine($"Gewicht: {weight} kg");

            decimal salary = 1564.32154m;
            Console.WriteLine($"Gehalt: € {salary}");            
        }
    }
}
