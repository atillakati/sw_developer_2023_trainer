using System;

namespace FahrzeugVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] myVehicleList = new Vehicle[]
            {
                new Vehicle(),
                new Vehicle("Super Badmobil", 250, 512, ConsoleColor.Cyan),
                new Vehicle("Schoolbus #1", 95, 308, ConsoleColor.Yellow),
                new Bike(),
                new Bike("Moto Cross", 80, 135, ConsoleColor.Red, 250)
            };

            foreach (var vehicle in myVehicleList)
            {
                //Fahrzeug Farbe setzen
                Console.ForegroundColor = vehicle.Color;

                //Fahrzeug beschleunigen
                vehicle.SpeedUp(vehicle.MaxSpeed / 2);

                //Ausgabe
                vehicle.ShowInfo();
                Console.WriteLine();
            }

            Console.ResetColor();

            //Bike bike = new Bike();
            //Bike cross = new Bike("Moto Cross", 80, 135, ConsoleColor.Red, 250);

            //bike.ShowInfo();
            //cross.ShowInfo();
        }
    }
}
