using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //alt = Array
            var nameListArray = new string[]
            {
                "Alf", "Gandalf", "Max"
            };

            var nameList = new List<string>();
            var dateList = new List<DateTime>();                        

            nameList.Add("Gandalf");
            nameList.Add("Sauron");
            nameList.Add("Eomer");

            nameList.Remove("Sauron");

            DisplayItems(nameList);
            DisplayItems(nameListArray);
        }

        private static void DisplayItems(IEnumerable<string> nameList)
        {            
            foreach (var item in nameList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
