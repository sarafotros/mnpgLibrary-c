using System;

namespace MoonpigLibrary
{
    public class Book
    { 
        public Book(string title, string author, float rate, int idBook)
        {
            Title = title;
            Author = author;
            Rate = rate;
            IdBook = idBook;
        }
        public string Title { get; }
        private string Author { get; }
        private float Rate { get; }
        public int IdBook { get; }

        public DateTime DateBorrowed { get; private set; }

        public DateTime DueTimeToReturn { get; private set; }

        public void PrintDetails()
        {
            Console.WriteLine($"{IdBook}) {Title} by {Author} (rated {Rate} / 5)");
        }

        public void DateBorrowedSet()
        {
            DateBorrowed = DateTime.Now;
            DueTimeToReturn = DateBorrowed.AddDays(7);
        }
    }
}