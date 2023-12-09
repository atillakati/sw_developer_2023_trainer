using System;
using Polymorphie.ShapeTypes;

namespace Polymorphie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //eine Liste mit versch. Shape Arten
            var shapeList = new Shape[]
            {
                new Kreis("Olaf", 5, ConsoleColor.Green),
                new Shape("Shape Standard", 5, ConsoleColor.Red),
                new Vieleck("Vivien", 34, ConsoleColor.Blue),
                new Dreieck("Dieter", ConsoleColor.Yellow),
                new Kreis("Olga", 10, ConsoleColor.Cyan)
            };

            //Darstellung aller Shapes
            DisplayShapes(shapeList);
        }

        private static void DisplayShapes(Shape[] shapeList)
        {
            foreach (var shape in shapeList)
            {
                shape.Draw();
            }
        }
    }
}
