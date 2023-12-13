using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class SearchByTitleMenu : Menu
    {
        public SearchByTitleMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj tytuł:");
                string searchingTitle = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine($"Czy tytuł, po którym chcesz wyszukać książkę ma następującą nazwę: {searchingTitle}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                Console.WriteLine("");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = library.getAllBooks();
                    bool isAvailable = false;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Książki o tytule {searchingTitle}:");
                    Console.ResetColor();
                    Console.WriteLine("");
                    foreach (var book in allBooks)
                    {
                        if (book.getTitle().Contains(searchingTitle))
                        {
                            Console.WriteLine(book);
                            isAvailable = true;
                            break;
                        }
                    }
                    Console.WriteLine("");
                    if (isAvailable == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Niestety nie ma książki o takim tytule na stanie");
                        Console.ResetColor();
                        Console.WriteLine("");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    printMenu();
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaj poprawną opcję!");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
        }
    }
}
