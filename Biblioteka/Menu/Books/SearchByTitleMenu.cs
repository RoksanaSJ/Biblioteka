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
        public void searchByTitleMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj tytuł:");
                string searchingTitle = Console.ReadLine();
                Console.WriteLine($"Czy tytuł, po którym chcesz wyszukać książkę ma następująca nazwę: {searchingTitle}");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                char userOption = char.Parse(Console.ReadLine());
                if (userOption == 'y')
                {
                    List<Book> allBooks = library.getAllBooks();
                    bool isAvailable = false;

                    foreach (var book in allBooks)
                    {
                        if (book.getTitle().Contains(searchingTitle))
                        {
                            Console.WriteLine(book);
                            isAvailable = true;
                        }
                    }
                    if (isAvailable == false)
                    {
                        Console.WriteLine("Niestety nie ma książki o takim tytule na stanie");
                    }
                }
                else if (userOption == 'n')
                {
                    searchByTitleMenu();
                }
                else if (userOption == 'b')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
            Console.WriteLine(" ");
        }
    }
}
