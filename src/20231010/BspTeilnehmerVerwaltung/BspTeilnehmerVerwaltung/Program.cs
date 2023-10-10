using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BspTeilnehmerVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variablen Deklaration & Initialisierung
            string name = string.Empty;
            string vorname = string.Empty;
            DateTime geburtsDatum = DateTime.MinValue;
            string input = string.Empty;
            int xTitelPos = 0;

            //Header
            #region Header            
            Console.Clear();

            //Darstellung Programm Header
            string titel = "Teilnehmer Verwaltung v1.0";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (titel.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(" " + titel + " ");

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = titel;
            #endregion

            //Eingabe der Daten
            #region Eingabe der Daten
            Console.WriteLine("Teilnehmer Daten eingeben:");
            Console.Write("\tVorname:      ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            vorname = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\tNachname:     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\tGeburtsdatum (dd-mm-YYYY): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine();
            Console.ResetColor();

            try
            {
                geburtsDatum = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\aERROR: Ungültige Datumseingabe.");
                geburtsDatum = DateTime.MinValue;
                Console.ResetColor();
            }
            #endregion            

            //Validierung des Wertebereichs für Geburtsdatum (16 - 95)
            #region Validierung                 
            if (geburtsDatum.Year == DateTime.MinValue.Year)
            {
                return;
            }

            int alter = DateTime.Now.Year - geburtsDatum.Year;
            if (alter < 16 || alter > 95)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR:\a Leider ist der Teilnehmer ausserhalb des gültigen Altersbereiches.");
                Console.ResetColor();
                return;
            }
            #endregion

            //Ausgabe der Daten
            #region Ausgabe
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTeilnehmerdaten:\n");
            Console.WriteLine($"\tVorname:       {vorname}");
            Console.WriteLine($"\tName:          {name}");            
            Console.WriteLine($"\tGeburtsdatum:  {geburtsDatum.ToLongDateString()}");
            Console.ResetColor();
            #endregion
        }
    }
}
