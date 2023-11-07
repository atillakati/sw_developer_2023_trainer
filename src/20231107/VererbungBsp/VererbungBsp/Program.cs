using System;
using System.Collections.Generic;
using VererbungBsp.Shapes;

namespace VererbungBsp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            var myShapeList = new Shape[]
            {
                new Shape("Fredy", 5, ConsoleColor.Red),
                new Vieleck("Ecki", 10, ConsoleColor.Yellow),
                new Kreis("Olga", ConsoleColor.Blue),
                new Dreieck("Triss", ConsoleColor.Green),
            };
           
            DisplayShapes(myShapeList);            
        }

        private static void DisplayShapes(Shape[] myShapeList)
        {
            foreach (Shape myShape in myShapeList)
            {
                myShape.Draw();
            }
        }
    }
}
