using System;

namespace Abfragen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 7;
            bool isPowerOn = false;

            if(zahl >= 5)
            {
                Console.WriteLine("...ist grösser gleich fünf.");                            
            }            
            else
            {
                Console.WriteLine("...ist kleiner fünf.");
            }

            //3..5
            //100..200
            if (zahl >= 3 && zahl <= 5) 
            {
                Console.WriteLine("Zahl liegt im gültigen Bereich.");
            }

            if(!isPowerOn)
            {
                Console.Clear();
            }

            Console.WriteLine("Ende");

        }
    }
}
