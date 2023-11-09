using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Employee
    {
        private string _name;
        private Guid _id;
        private DateTime _birthdate;

        public Employee(string name, DateTime birthdate)
        {
            _id = Guid.NewGuid();
            _name = name;
            _birthdate = birthdate;
        }

        public Employee(Guid id, string name, DateTime birthdate)
        {
            _id = id;
            _name = name;
            _birthdate = birthdate;
        }

        public string Name
        {
            get { return _name; }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public int BirthYear
        {
            get { return _birthdate.Year; }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"[{_id}] - {_name}");
            Console.WriteLine($"Geburtsdatum: {_birthdate.ToShortDateString()}");
        }
    }
}
