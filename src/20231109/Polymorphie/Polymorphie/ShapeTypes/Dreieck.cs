using System;

namespace Polymorphie.ShapeTypes
{
    internal class Dreieck : Vieleck
    {
        public Dreieck(string description, ConsoleColor color)
            : base("Dreieck " + description, 3, color)
        {

        }
    }
}
