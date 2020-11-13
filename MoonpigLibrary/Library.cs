using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonpigLibrary
{
    public class Library
    {
        public List<Book> ListAllBooks { get; }
        public List<Book> Basket { get; set; }

        public Library()
        {
            ListAllBooks = new List<Book>()
            {
                new Book("Clean Code", "Robert C. Martin", 3.8f, 1),
                new Book("The Clean Coder","Rober C. Martin",4.9f, 2),
                new Book("Design Patterns", "Erich Gamma et al",4.3f, 3),
                new Book("Domain Driven Design", "Eric Evans", 4f,4 ),
                new Book("Head First Design Patterns", "Eric Freeman et al", 4.8f, 5),
                new Book("Building Microservices","Sam Newman",2.5f, 6)
            };
           Basket = new List<Book>();
        }

        public string BorrowABook(Book book)
        {
            if (!Basket.Any())
            {
                book.DateBorrowedSet();
                Basket.Add(book);
                var formatDate = "MMM ddd d HH:mm";
                var dateOfBorrow = book.DateBorrowed.ToString(formatDate);
                var dueDateToReturn = book.DueTimeToReturn.ToString(formatDate);
                return $"'{book.Title}' added to your basket on {dateOfBorrow};\nShould be returned by => {dueDateToReturn}";
            }
            else
            {
                return "You can only borrow one book at a time";
            }
        }

        public void ReturnABook(Book book)
        {
            Basket.Remove(book);
        }
    }
}