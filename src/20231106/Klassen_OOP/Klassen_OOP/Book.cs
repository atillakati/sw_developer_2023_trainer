using System;

namespace Klassen_OOP
{
    internal class Book
    {        
        public int PageCount;
        public string Title;
        public string Author;
        public string Isbn;
        public decimal Price;

        public Guid Id;
        public bool IsAvailable;
        public DateTime StartBorrowingDate;
        public DateTime StopBorrowingDate;
        public bool ReturnDateOverdrawn;

        //std. Konstruktor
        //public Book()
        //{
        //    InitBorrowStateInfo();

        //    PageCount = 0;
        //    Title = string.Empty;
        //    Author = string.Empty;
        //    Isbn = string.Empty;
        //    Price = 0.0m;
        //}        

        //User spezific konstruktor
        public Book(string title, string author, string isbn, int pageCount, decimal price)
        {
            InitBorrowStateInfo();

            Title = title;
            Author = author;
            Isbn = isbn;
            PageCount = pageCount;
            Price = price;
        }

        private void InitBorrowStateInfo()
        {
            Id = Guid.NewGuid();
            IsAvailable = true;
            StartBorrowingDate = DateTime.MinValue;
            StopBorrowingDate = DateTime.MinValue;
            ReturnDateOverdrawn = false;
        }

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

        public void DisplayInfo()
        {
            //ReturnDateOverdrawn = StopBorrowingDate < DateTime.Now;

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
