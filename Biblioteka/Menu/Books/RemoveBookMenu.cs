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
        public override void printMenu()
        {
                Console.WriteLine("Podaj tytuł książki, którą chcesz usunąć");
                string title = Console.ReadLine();
                List<Book> toRemove = new List<Book>();
                List<Book> allBooks = library.getAllBooks();
                foreach (var book in allBooks)
                {
                    if (book.getTitle().Contains(title))
                    {
                        Console.WriteLine($"Czy to jest ta ksiażka, którą chcesz usunąć? {book}?");
                        Console.WriteLine("Wpisz 'y' jeśli tak, 'n' jeśli nie 'b' jeśli chcesz wrócić");
                        string option = Console.ReadLine();
                        Console.WriteLine("");
                        if (option.Equals("y"))
                        {
                            toRemove.Add(book);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Gratulację, właśnie usunąleś książkę {book}");
                            Console.ResetColor();
                            Console.WriteLine("");
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podaj właściwą opcję!");
                            Console.ResetColor();
                            Console.WriteLine("");
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
