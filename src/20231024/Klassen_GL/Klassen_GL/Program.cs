using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book();

            myBook.StartBorrowing(TimeSpan.FromDays(7));
            myBook.DisplayInfos();

            myBook.StopBorrowingDate = new DateTime(2030, 5, 3);

            myBook.DisplayInfos();
        }
    }
}
