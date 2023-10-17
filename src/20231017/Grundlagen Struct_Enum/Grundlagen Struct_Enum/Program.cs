using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Struct_Enum
{
    public struct Teilnehmer
    {
        public string Name;
        public string Nachname;
        public DateTime Geburtsdatum;
        public int Plz;
        public string Ort;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Name, Vornamen, Geburtsdatum, Plz, Ort

            //Deklaration
            int zahl;            
            Teilnehmer teilnehmer;
            Teilnehmer teilnehmer2;

            //Initialilsierung
            zahl = 0;
            
            teilnehmer = new Teilnehmer();

            teilnehmer.Name = string.Empty;
            teilnehmer.Nachname = string.Empty;
            teilnehmer.Ort = string.Empty;
            teilnehmer.Geburtsdatum = DateTime.MinValue;
            teilnehmer.Plz = 0;

            teilnehmer.Name = "Atilla";

            Console.WriteLine(zahl);
            Console.WriteLine(teilnehmer.Name);
            Console.WriteLine(teilnehmer.Nachname);
            Console.WriteLine(teilnehmer.Geburtsdatum);

            DisplayTeilnehmerData(teilnehmer);
        }

        static Teilnehmer ReadData()
        {
            return new Teilnehmer();
        }

        private static void DisplayTeilnehmerData(Teilnehmer teilnehmer)
        {
           
        }
    }
}
