using System;

namespace Polymorphie.ShapeTypes
{
    internal class Shape
    {
        private string _description;
        private int _cornerCount;
        private ConsoleColor _color;


        public Shape(string description, int cornerCount)
            : this(description, cornerCount, ConsoleColor.Gray) { }

        public Shape(string description, int cornerCount, ConsoleColor shapeColor)
        {
            _description = description;
            _cornerCount = cornerCount;
            _color = shapeColor;
        }


        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int CornerCount
        {
            get { return _cornerCount; }
        }

        public virtual string Description
        {
            get { return _description; }
        }

        public virtual void Draw()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"Shape '{_description}' mit {_cornerCount} Ecken wird dargestellt.");

            Console.ForegroundColor = oldColor;
        }
    }
}