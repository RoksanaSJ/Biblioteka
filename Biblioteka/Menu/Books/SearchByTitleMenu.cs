using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;
using Biblioteka.Repository;

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
                Console.WriteLine($"\nCzy tytuł, po którym chcesz wyszukać książkę ma następującą nazwę: {searchingTitle}?");
                Console.WriteLine("\nJeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    Log.PrintInformationMessage("Dostępne książki do wypożyczenia:");
                    List<Book> availableBooks = Library.GetBookRepository().GetAvailableBooks(searchingTitle);
                    foreach (Book book in availableBooks)
                    {
                        Console.WriteLine(book);
                    }
                    if (availableBooks.Count() == 0)
                    {
                        Log.PrintErrorMessage("Niestety nie ma książek o takim tytule na stanie");
                    }
                    Console.WriteLine($"Dostępnych książek o tym tytule jest: {availableBooks.Count()}");
                    Console.WriteLine("");
                    List<Book> bookedBooks = Library.GetBookRepository().GetBookedBooks(searchingTitle);
                    foreach (Book book in bookedBooks)
                    {
                        Console.WriteLine(book);
                    }
                    if (bookedBooks.Count() == 0)
                    {
                        Log.PrintErrorMessage("Nie ma wypożyczonych książek o takim tytule");
                    }
                    Log.PrintInformationMessage($"Wypożyczonych ksiażek o tym tytule jest: {bookedBooks.Count()}");
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
