using System;

namespace SpielZahlenRaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN_VALUE = 1;
            const int MAX_VALUE = 100;
            TimeSpan MAX_GAME_DURATION = TimeSpan.FromSeconds(10);

            int xTitelPos = 0;
            int userInputValue = 0;
            int randomValue = 0;
            bool isInputValid = false;

            #region Header            
            Console.Clear();

            //Darstellung Programm Header
            string titel = "Spiel Zahlen raten v1.0";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (titel.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" " + titel + " ");
            Console.ResetColor();

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = titel;
            #endregion

            //DateTime startTime = DateTime.Now;
            //DateTime endTime = DateTime.MinValue;  
            //TimeSpan gameDuration = TimeSpan.Zero;

            //zufallszahl ermitteln
            Random rnd = new Random();
            randomValue = rnd.Next(MIN_VALUE, MAX_VALUE + 1);

            Console.WriteLine($"Sie sollen eine Zahl zwischen {MIN_VALUE} und {MAX_VALUE} erraten! Los geht's!\n");
            do
            {
                do
                {
                    try
                    {
                        Console.Write("Ihre Eingabe: ");
                        userInputValue = int.Parse(Console.ReadLine());

                        isInputValid = true;
                    }
                    catch
                    {                        
                        isInputValid = false; 
                    }

                    //endTime = DateTime.Now;

                    //TimeSpan currentDuration = endTime - startTime;
                    //if(currentDuration > MAX_GAME_DURATION)
                    //{
                    //    Console.SetCursorPosition(35, Console.CursorTop - 1);

                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Leider Spielzeit abgelaufen!");
                    //    Console.ResetColor();

                    //    return;
                    //}

                    //range and input check
                    if (!isInputValid || userInputValue < MIN_VALUE || userInputValue > MAX_VALUE)
                    {
                        Console.SetCursorPosition(35, Console.CursorTop - 1);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: Ungültige Eingabe. Bitte erneut versuchen!");
                        Console.ResetColor();
                        
                        isInputValid = false;
                    }
                }
                while (!isInputValid);

                if (userInputValue < randomValue)
                {
                    Console.WriteLine("Die Zahl ist grösser!");
                }
                else if (userInputValue > randomValue)
                {
                    Console.WriteLine("Die Zahl ist kleiner!");
                }
            }
            while (userInputValue != randomValue);

            Console.WriteLine("\a\a\nG E W O N N E N !");
        }
    }
}
