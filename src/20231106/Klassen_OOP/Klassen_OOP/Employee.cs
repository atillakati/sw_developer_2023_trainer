using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_OOP
{
    internal class Employee
    {
        public string Name;
        public Guid Id;

        public Employee(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"[{Id}] - {Name}");
        }
    }
}
