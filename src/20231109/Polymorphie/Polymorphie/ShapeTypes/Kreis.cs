﻿using System;

namespace Polymorphie.ShapeTypes
{
    internal class Kreis : Shape
    {
        public Kreis(string description, ConsoleColor color)
            : base("Kreis " + description, 0, color)
        {

        }
    }
}
