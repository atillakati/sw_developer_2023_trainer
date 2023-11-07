using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    internal class Bike : Vehicle
    {
		private int _suspensionTravel;

        public Bike() 
            : base("Vespa Std.", 40, 5, ConsoleColor.Red)
        {
            _suspensionTravel = 180;
        }
        
        public Bike(string bikeDescription, int ps, int maxSpeed, ConsoleColor bikeColor, int suspensionTravel)
            : base(bikeDescription, maxSpeed, ps, bikeColor)
        {
            _suspensionTravel = suspensionTravel;            
        }

        public int SuspensionTravel
		{
			get { return _suspensionTravel; }			
		}

	}
}
