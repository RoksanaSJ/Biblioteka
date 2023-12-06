using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;
//using static Biblioteka.Book;

namespace Biblioteka.Menu.Books
{
    internal class RemoveBookMenu : Menu
    {
        public RemoveBookMenu(Library library) : base(library)
        {

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
                    else
                    {
                        Console.WriteLine("Podaj właściwą opcję!");
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
