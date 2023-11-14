using System;
using System.Globalization;


namespace Wifi.UITools
{
    public delegate void InvalidInputHandler(string invalidUserInput);

    /// <summary>
    /// Sammelsurium von Methoden für die Arbeit in der Console.
    /// </summary>
    public abstract class ConsoleTools 
    {
        /// <summary>
        /// Liefert eine Eingabe als string zurück. string.Empty und NULL werden nicht akzeptiert.
        /// </summary>
        /// <param name="inputPrompt">Text für die Eingabeaufforderung</param>
        /// <returns></returns>
        public static string ReadString(string inputPrompt)
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

        public static int ReadInt(string inputPrompt)
        {
            return ReadInt(inputPrompt, DefaultErrorHandler);
        }

        public static int ReadInt(string inputPrompt, InvalidInputHandler invalidInputHandler)
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
                    if (invalidInputHandler != null)
                    {
                        invalidInputHandler(input);
                    }
                    //invalidInputHandler?.Invoke(input);

                    inputValue = 0;
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }

        private static void DefaultErrorHandler(string invalidUserInput)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\aERROR: Ungültige Eingabe.");            
            Console.ResetColor();            
        }

        public static DateTime ReadDateTime(string inputPrompt)
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

        /// <summary>
        /// Generiert eine Überschrift mit einem Titel.       
        /// </summary>
        /// <param name="headerText">Der Titel der in der Überschrift dargestellt werden soll.</param>
        /// <param name="headerTextColor">Die Farbe in welcher der Titel dargestellt werden soll.</param>
        /// <param name="clearScreen">true, wenn der Bildschirm vor der Ausgabe gelöscht werden soll, sonst false.</param>
        public static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
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
