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
        public override void PrintMenu()
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
                    List<Book> allBooks = Library.GetAllBooks();
                    bool isAvailable = false;
                    Log.PrintInformationMessage($"Książki o tytule {searchingTitle}:");
                    Console.WriteLine("");
                    foreach (var book in allBooks)
                    {
                        if (book.GetTitle().Contains(searchingTitle))
                        {
                            Console.WriteLine(book);
                            isAvailable = true;
                            break;
                        }
                    }
                    Console.WriteLine("");
                    if (isAvailable == false)
                    {
                        Log.PrintErrorMessage("Niestety nie ma książki o takim tytule na stanie");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    continue;
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
