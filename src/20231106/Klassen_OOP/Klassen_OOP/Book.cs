using System;

namespace Klassen_OOP
{
    internal class Book
    {        
        private int _pageCount;
        private string _title;
        private string _author;
        private string _isbn;
        private decimal _price;
        
        private Guid _id;
        private bool _isAvailable;
        private DateTime _startBorrowingDate;
        private DateTime _stopBorrowingDate;
        private bool _returnDateOverdrawn;

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

            _title = title;
            _author = author;
            _isbn = isbn;
            _pageCount = pageCount;
            _price = price;
        }


        ////Zugriffsmethode
        //public string GetTitle()
        //{
        //    return Title;
        //}

        //Eigenschaft = Property
        public string Title
        {
            get
            {                
                return _title;
            }

            //set
            //{
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        _title = value;
            //    }
            //}
        }

        public decimal Price
        {
            get { return _price; }
            
            set 
            {
                if (value > 0.00m && value < 180.0m)
                {
                    _price = value;
                }
            }
        }
        
        ////Änderungsmethode
        //public void SetPrice(decimal newPrice)
        //{
        //    if (newPrice > 0.00m && newPrice < 180.0m)
        //    {
        //        Price = newPrice;
        //    }
        //}


        private void InitBorrowStateInfo()
        {
            _id = Guid.NewGuid();
            _isAvailable = true;
            _startBorrowingDate = DateTime.MinValue;
            _stopBorrowingDate = DateTime.MinValue;
            _returnDateOverdrawn = false;
        }

        public void StartBorrowing(TimeSpan duration)
        {
            _startBorrowingDate = DateTime.Now;
            _stopBorrowingDate = _startBorrowingDate.Add(duration);

            _isAvailable = false;
            _returnDateOverdrawn = _stopBorrowingDate < DateTime.Now;
        }

        public void EndBorrowing()
        {
            _isAvailable = true;
            _returnDateOverdrawn = false;
        }

        public void DisplayInfo()
        {
            //ReturnDateOverdrawn = StopBorrowingDate < DateTime.Now;

            Console.WriteLine($"ID: {_id}");
            Console.WriteLine($"Titel: {_title} [{_author}]");
            Console.WriteLine($"Available: {_isAvailable}");
            Console.WriteLine($"Overdrawn: {_returnDateOverdrawn}");

            if (!_isAvailable)
            {
                Console.WriteLine($"\tStart: {_startBorrowingDate.ToShortDateString()}");
                Console.WriteLine($"\tUntil: {_stopBorrowingDate.ToShortDateString()}");
            }
        }
    }
}
