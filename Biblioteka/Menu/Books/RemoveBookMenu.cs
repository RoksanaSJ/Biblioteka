using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Biblioteka.Book;

namespace Biblioteka.Menu.Books
{
    internal class RemoveBookMenu
    {
        Library library;
        public RemoveBookMenu(Library library)
        {
            this.library = library;
        }

        public void removeBookMenu()
        {
            Console.WriteLine("Podaj tytuł książki, którą chcesz usunąć");
            string title = Console.ReadLine();
            List<Book> toRemove = new List<Book>();
            List<Book> allBooks = library.getAllBooks();
            foreach (var book in allBooks)
            {
                if (book.getTitle().Contains(title))
                {
                    Console.WriteLine($"Czy to jest ta ksiażka, którą chcesz usunąć? {book}");
                    Console.WriteLine("Wpisz y jeśli tak lub n jeśli nie");
                    string option = Console.ReadLine();
                    if (option.Equals("y"))
                    {
                        toRemove.Add(book);
                    }
                    else if (option.Equals("n"))
                    {
                        continue;
                    }
                }
            }
            foreach (var book in toRemove)
            {
                allBooks.Remove(book);
            }
        }
    }
}
