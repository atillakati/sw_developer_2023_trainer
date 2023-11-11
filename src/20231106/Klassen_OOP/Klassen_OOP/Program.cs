using System;


namespace Klassen_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanz
            //Book myBook = new Book();

            Book aBook = new Book("Die unendliche Geschichte", "Michael Ende", "X-3215321-321-9", 550, 26.90m);

            //1. Initialisierung?  DONE!
            //2. Zustandsinformationen nicht geschützt!

            Console.WriteLine($"Titel: {aBook.Title}");

            //aBook.Title = "Test";

            //aBook.DisplayInfo();


            Employee ma = new Employee("Max Mustermann", new DateTime(1980, 5, 20));

            Console.WriteLine($"Geburtsjahr: {ma.BirthYear}");
            ma.ShowInfo();
            
        }
    }
}
