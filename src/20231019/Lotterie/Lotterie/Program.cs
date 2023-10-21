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
        private const int MAX_COLUMN_COUNT = 6;

        static void Main(string[] args)
        {
            int tipCounter = 0;
            int startPosTop = 6;
            int startPosLeft = 6;

            CreateHeader("Lotto 6 aus 45", ConsoleColor.Yellow, true);
            TipDisplayConfiguration displayConfig = CreateDisplayConfig();
                        
            tipCounter = ReadInt("Bitte die Anzahl der Tips eingeben: ", 0, 12);
            startPosTop = Console.CursorTop + 1;
            
            for (int i = 0; i < tipCounter; i++)
            {
                int[] tip = CreateTip(1, MAX_VALUE, MAX_VALUE_COUNT);

                displayConfig.Position = CalcDisplayPosition(startPosTop, startPosLeft, i);                
                DisplayTip(tip, displayConfig);
            }

            Console.WriteLine();
        }

        private static TipDisplayConfiguration CreateDisplayConfig()
        {
            TipDisplayConfiguration displayConfig = new TipDisplayConfiguration();

            displayConfig.Foreground = ConsoleColor.DarkGray;
            displayConfig.HighlightForeground = ConsoleColor.Yellow;
            displayConfig.HighlightBackground = ConsoleColor.DarkGray;

            return displayConfig;
        }

        private static DisplayPosition CalcDisplayPosition(int startPositionTop, int startPositionLeft, int tipCounter)
        {
            const int TIP_WIDTH = 21;
            const int TIP_HIGHT = 9;

            int column = tipCounter % MAX_COLUMN_COUNT;
            int row = tipCounter / MAX_COLUMN_COUNT;

            return new DisplayPosition
            {
                Top = startPositionTop + row * TIP_HIGHT,
                Left = startPositionLeft + column * TIP_WIDTH
            };
        }
        
        private static void DisplayTip(int[] tip, TipDisplayConfiguration displayConfig)
        {
            int charCounter = 0;
            int lineCounter = displayConfig.Position.Top;

            Array.Sort(tip);

            Console.SetCursorPosition(displayConfig.Position.Left, lineCounter++);

            for (int i = 1; i <= MAX_VALUE; i++)
            {
                if (ExistsInList(tip, i))
                {
                    Console.ForegroundColor = displayConfig.HighlightForeground;
                    Console.BackgroundColor = displayConfig.HighlightBackground;
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = displayConfig.Foreground;
                }

                Console.Write($"{i:00}");
                Console.ResetColor();
                Console.Write(" ");
                charCounter++;

                if (charCounter >= 6)
                {
                    charCounter = 0;
                    Console.WriteLine();
                    Console.SetCursorPosition(displayConfig.Position.Left, lineCounter++);
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        private static int[] CreateTip(int minValue, int maxValue, int valueCount)
        {
            int[] values = new int[valueCount];
            int randomValue = 0;

            for (int i = 0; i < valueCount; i++)
            {
                randomValue = rnd.Next(minValue, maxValue + 1);
                if (!ExistsInList(values, randomValue))
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
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == newValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static int ReadInt(string inputPrompt, int minInputValue, int maxInputValue)
        {
            bool valueIsValid = false;
            int inputValue = 0;

            do
            {
                valueIsValid = true;

                inputValue = ReadInt(inputPrompt);
                if(inputValue < minInputValue || inputValue > maxInputValue)
                {
                    Console.WriteLine($"ERROR: Eingabe ausserhalb des gültigen Wertebereichs ({minInputValue} - {maxInputValue}).");
                    valueIsValid = false;
                }
            }
            while (!valueIsValid);

            return inputValue;
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
