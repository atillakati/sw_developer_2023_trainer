using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeList = new Employee[]
            {
                new Developer(Guid.NewGuid(), "Max Musterman", new DateTime(1980,5,10), 1800.00m),
                new Developer(Guid.NewGuid(), "Lars Grünschnabel", new DateTime(2003,5,10), 1800.00m)
            };

            StartCalculation(employeeList);
        }

        private static void StartCalculation(IPersistable[] employeeList)
        {
            foreach (var ma in employeeList)
            {
                Console.WriteLine("Infos über: " + ma.Name);
                
                ma.ShowInfo();
                Console.WriteLine($"Gehalt: EUR {ma.CalculateSallery():#,000.00}\n");
            }            
        }
    }
}
