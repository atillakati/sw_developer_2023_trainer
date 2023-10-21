using System;
using System.Globalization;
using System.Runtime.Versioning;

namespace Lotterie
{
    internal class Program
    {
        static Random rnd = new Random();
        private const int MAX_VALUE = 45;
        private const int MAX_VALUE_COUNT = 6;

        static void Main(string[] args)
        {
            int tipCounter = 0;
            int startPosx = 3;
            int startPosy = 6;

            CreateHeader("Lotto 6 aus 45", ConsoleColor.Yellow, true);

            tipCounter = ReadInt("Bitte die Anzahl der Tips eingeben: ");
                        
            for (int i = 0; i < tipCounter; i++)
            {
                int[] tip = CreateTip(1, MAX_VALUE, MAX_VALUE_COUNT);

                //TODO: Die Berechnung der Ausgabeposition ist nicht cool.
                startPosx = 3 + i * 21;
                if(startPosx + 21 > Console.WindowWidth)
                {
                    startPosx = 3;
                    startPosy += 9;
                }

                DisplayTip(tip, startPosx, startPosy);
            }

            Console.WriteLine();            
        }

        private static void DisplayValues(int[] tip)
        {
            Array.Sort(tip);

            for (int i = 0; i < tip.Length; i++)
            {
                Console.Write($"{tip[i]:00} ");
            }
            Console.WriteLine("\n");
        }

        private static void DisplayTip(int[] tip, int left, int top)
        {
            int charCounter = 0;
            int lineCounter = top;

            Array.Sort(tip);

            Console.SetCursorPosition(left, lineCounter++);

            for (int i = 1; i <= MAX_VALUE; i++)
            {
                if (ExistsInList(tip, i))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.Write($"{i:00} ");
                charCounter++;

                if (charCounter >= 6)
                {
                    charCounter = 0;
                    Console.WriteLine();
                    Console.SetCursorPosition(left, lineCounter++);
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        private static void DisplayTip(int[] tip)
        {
            int charCounter = 0;

            Array.Sort(tip);

            for (int i = 1; i <= MAX_VALUE; i++)
            {
                if (ExistsInList(tip, i)) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.Write($"{i:00} ");
                charCounter++;

                if (charCounter >= 6)
                {
                    charCounter = 0;
                    Console.WriteLine();
                }
            }
          
            Console.ResetColor();
            Console.WriteLine();
        }

        private static int[] CreateTip(int minValue, int maxValue, int valueCount)
        {            
            int[] values = new int[valueCount];
            int randomValue = 0;

            for (int i = 0; i<valueCount; i++)
            {
                randomValue = rnd.Next(minValue, maxValue+1);
                if(!ExistsInList(values, randomValue))
                {
                    values[i] = randomValue;
                }
                else
                {
                    i--;
                }
            }

            return values;
        }

        private static bool ExistsInList(int[] values, int newValue)
        {
            for (int i = 0;i<values.Length;i++)
            {
                if (values[i] == newValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static string ReadString(string inputPrompt)
        {
            string input = string.Empty;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        private static int ReadInt(string inputPrompt)
        {
            string input = string.Empty;
            int inputValue = 0;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    inputValue = int.Parse(input);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Eingabe.");
                    inputValue = 0;
                    Console.ResetColor();
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }

        private static DateTime ReadDateTime(string inputPrompt)
        {
            string input = string.Empty;
            DateTime inputDateTime = DateTime.MinValue;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    inputDateTime = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Datumseingabe.");
                    inputDateTime = DateTime.MinValue;
                    Console.ResetColor();
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputDateTime;
        }

        private static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
        {
            int xTitelPos = 0;

            //soll der bildschirm gelöscht werden?
            if (clearScreen)
            {
                Console.Clear();
            }

            //Darstellung Programm Header            
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (headerText.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = headerTextColor;
            Console.Write(" " + headerText + " ");
            Console.ForegroundColor = oldColor;

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = headerText;
        }
    }
}
