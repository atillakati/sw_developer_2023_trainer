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
            
            aBook.DisplayInfo();

            Employee ma = new Employee("Gandalf Sehralt");

            ma.ShowInfo();

        }
    }
}
