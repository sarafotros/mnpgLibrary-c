using System;
using System.Globalization;
using System.Linq;

namespace MoonpigLibrary
{
    public class Reception
    {
        private Library _library;
        public Reception()
        {
            _library = new Library();
        }
        public void Open()
        {
            var dateTimeNow = DateTime.Now;
            Console.WriteLine(" ---------__________---------__________---------");
            Console.WriteLine("           Welcome to MOONPIG Library\r");
            var format = "MMM ddd d HH:mm";
            Console.WriteLine($"  ...:::     Today is  {dateTimeNow.ToString(format)}    :::...");
            Console.WriteLine(" ________---------__________-----------________\n");
            var close = false;
            while (!close)
            {
                Console.WriteLine("How can we help?");
                Console.WriteLine("1) List of all the books\n2) List of your books\n3) Return a book\n4) Exit");
                var selectedOption =  Console.ReadLine();
                switch (selectedOption)
                {
                    case "1" :
                        ShowListOfAllBooks();
                        break;
                    case "2" :
                        Console.WriteLine("________________________");
                        ListOfBorrowedBooks();
                        break;
                    case "3" :
                        Console.WriteLine("------------------------");
                        ReturnBookToLibrary();
                        break;
                    case "4" :
                        Console.WriteLine("Goodbye");
                        close = true;
                        break;
                    default:
                        Console.WriteLine("You didn't choose a valid option!");
                        break;
                }
            }
        }

        private void ShowListOfAllBooks()
        {
            _library.ListAllBooks.ForEach(book => book.PrintDetails());
            Console.WriteLine("=======================");
            Console.WriteLine("Do you want to borrow book? ");
            Console.WriteLine("[Y] Yes   [N] No");
            var wantBook = Console.ReadLine();
            switch (wantBook)
            {
                case "y" :
                    Console.WriteLine("Type the ID of the book you want to borrow:");
                    var chosenId = Console.ReadLine();
                    BorrowBook(chosenId);
                    break;
                case "n" :
                    Console.WriteLine("``````````````````````");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private void BorrowBook(string bookId)
        { 
           var chosenBook = _library.ListAllBooks.Single(b => b.IdBook == Int32.Parse(bookId));
           var result = _library.BorrowABook(chosenBook);
           Console.WriteLine(result);
        }

        private void ListOfBorrowedBooks()
        {
            if (_library.Basket.Any())
            {
                foreach (var book in _library.Basket)
                {
                    Console.WriteLine($"Your books: {book.Title}\nIts due date to return is on'{book.DueTimeToReturn.ToString("MMM ddd d HH:mm")}'");
                }
            }
            else
            {
                Console.WriteLine("You don't have any book in your basket");
            }
        }
        private void ReturnBookToLibrary()
        {
            var bookToReturn = _library.Basket.FirstOrDefault(); 
            if (bookToReturn != null)
            {
                _library.ReturnABook(bookToReturn);
                Console.WriteLine($"you have returned '{bookToReturn.Title}' and its due date was {bookToReturn.DueTimeToReturn}");
            }
            else
            {
                Console.WriteLine("You don't have any book to return");
            }
        }
        
    }
}