using System;

namespace EingabenGL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string eingabe = string.Empty;  
            int alter = 0;

            Console.Write("Bitte Name eingeben: ");
            name = Console.ReadLine();

            Console.WriteLine($"Hallo {name}, wie geht's?");

            Console.Write("Bitte Alter eingeben: ");
            eingabe = Console.ReadLine();
            
            //eingabe = "40"
            alter = int.Parse(eingabe);                        

            Console.WriteLine($"{name}, Sie sind {alter} Jahre jung.");
            Console.WriteLine($"Sie wurden im Jahr {2023 - alter} geboren.");            
        }
    }
}
