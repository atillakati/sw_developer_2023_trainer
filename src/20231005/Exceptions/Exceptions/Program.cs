using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int alter = 0;


            Console.Write("Alter eingeben: ");

            try
            {
                alter = int.Parse(Console.ReadLine());
            }
            catch(OverflowException oex) 
            {
                Console.WriteLine(oex.Message);
            }
            catch (FormatException ex)
            {

            }
            catch(Exception error) 
            {
                Console.WriteLine("\n\aERROR: " + error.Message);
            }


            Console.WriteLine("Ende.");
        }
    }
}
