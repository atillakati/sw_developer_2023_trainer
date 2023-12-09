using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methoden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            WriteHelloWorld();

            WriteColoredMessage("Dies ist ein Test.", ConsoleColor.Yellow);
            WriteColoredMessage("Dies ist ein Test.", ConsoleColor.Red);
            WriteHelloWorld();
            WriteColoredMessage("Dies ist ein Test.", ConsoleColor.Green);

            int erg = Addition(5, 51);
            
            Console.WriteLine(erg);

            //Methoden Überladung
            WriteColoredMessage("Hello!");
            WriteColoredMessage("Error...", ConsoleColor.Red);
        }

        static int Addition(int val1, int val2)
        {
            int summe = 0;

            summe = val1 + val2;
            
            return summe;
        }

        static void WriteColoredMessage(string message)
        {
            WriteColoredMessage(message, ConsoleColor.Yellow);
        }

        static void WriteColoredMessage(string message, ConsoleColor messageColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        //Signatur: Rückgabetyp Methodenbezeichnung( Parameterliste )
        static void WriteHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

    }
}
