using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class RemoveBookMenu : Menu
    {
        public RemoveBookMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
                Console.WriteLine("Podaj tytuł książki, którą chcesz usunąć");
                string title = Console.ReadLine();
                List<Book> toRemove = new List<Book>();
                List<Book> allBooks = Library.GetAllBooks();
                foreach (var book in allBooks)
                {
                    if (book.GetTitle().Contains(title))
                    {
                        Console.WriteLine($"Czy to jest ta ksiażka, którą chcesz usunąć? {book}?");
                        Console.WriteLine("Wpisz 'y' jeśli tak, 'n' jeśli nie 'b' jeśli chcesz wrócić");
                        string option = Console.ReadLine();
                        Console.WriteLine("");
                        if (option.Equals("y"))
                        {
                            toRemove.Add(book);
                            Log.PrintSuccessMessage($"Gratulację, właśnie usunąleś książkę {book}");
                        }
                        else if (option.Equals("n"))
                        {
                            continue;
                        }
                        else if (option.Equals("b"))
                        {
                            break;
                        }
                        else
                        {
                        Log.PrintErrorMessage("Podaj właściwą opcję!");
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
