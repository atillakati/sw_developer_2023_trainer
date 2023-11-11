using System;
using System.Security.Cryptography;
using System.Xml.Linq;


namespace AbstrakteDatentypen
{
    internal class Developer : Employee, IPersistable, IComparable, IConvertible
    {
        private decimal _baseSallery;
        private string _name;
        private Guid _id;
        private DateTime _birthdate;

        public Developer(Guid id, string name, DateTime birthday, decimal baseSallery)
        {
            _id = id;
            _name = name;
            _birthdate = birthday;
            _baseSallery = baseSallery;
        }

        public override string Name
        {
            get { return _name; }
        }

        public override Guid Id
        {
            get { return _id; }
        }

        public override int BirthYear
        {
            get { return _birthdate.Year; }
        }

        public string FileName => throw new NotImplementedException();

        public override decimal CalculateSallery()
        {
            var age = DateTime.Now.Year - BirthYear;
            var factor = age / 5;

            return _baseSallery * (1.00m + factor / 100.0m);
        }

        public bool Load(string fromFilename)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[{_id}] - {_name}");
            Console.WriteLine($"Geburtsdatum: {_birthdate.ToShortDateString()}");
        }
    }
}
