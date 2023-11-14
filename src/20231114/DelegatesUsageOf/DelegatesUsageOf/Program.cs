using System;
using Wifi.UITools;

namespace DelegatesUsageOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleTools.CreateHeader("Delegates Beispiel", ConsoleColor.Magenta, true);

            var alter = ConsoleTools.ReadInt("Alter eingeben: ", DisplayErrorOnSameLine);
        }

        private static void DisplayErrorOnSameLine(string invalidUserInput)
        {            
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine($"Eingabe '{invalidUserInput}' ungültig.");

            Console.ResetColor();
        }
    }
}
