using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_GL
{
    internal class Book
    {
        public Guid Id;
        public int PageCount;
        public string Title;
        public string Author;
        public string Isbn;
        public decimal Price;

        public bool IsAvailable;
        public DateTime StartBorrowingDate;
        public DateTime StopBorrowingDate;
        public bool ReturnDateOverdrawn;

        public void StartBorrowing(TimeSpan duration)
        {
            StartBorrowingDate = DateTime.Now;
            StopBorrowingDate = StartBorrowingDate.Add(duration);

            IsAvailable = false;
            ReturnDateOverdrawn = StopBorrowingDate < DateTime.Now;
        }

        public void EndBorrowing()
        {
            IsAvailable = true;
            ReturnDateOverdrawn = false;
        }

        public void DisplayInfos()
        {
            ReturnDateOverdrawn = StopBorrowingDate < DateTime.Now;

            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Titel: {Title} [{Author}]");
            Console.WriteLine($"Available: {IsAvailable}");
            Console.WriteLine($"Overdrawn: {ReturnDateOverdrawn}");

            if (!IsAvailable)
            {
                Console.WriteLine($"\tStart: {StartBorrowingDate.ToShortDateString()}");
                Console.WriteLine($"\tUntil: {StopBorrowingDate.ToShortDateString()}");
            }
        }
    }
}
