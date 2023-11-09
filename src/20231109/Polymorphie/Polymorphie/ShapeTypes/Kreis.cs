using System;

namespace Polymorphie.ShapeTypes
{
    internal class Kreis : Shape
    {
        private readonly string _kreisBezeichnung;
        private int _radius;        

        public Kreis(string kreisBezeichnung, int radius, ConsoleColor color)
            : base("Kreis", 0, color)
        {
            _kreisBezeichnung = kreisBezeichnung;
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override string Description
        {
            get { return "Kreis " + _kreisBezeichnung; }    
        }

        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine($"Hier {Description} mit Radius: {_radius}");            
        }
    }
}
