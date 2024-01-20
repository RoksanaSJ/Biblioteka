using Biblioteka.Model;
using Biblioteka.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchByID : Menu
    {
        public SearchByID(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID książki: ");
                int bookID = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nCzy ID, po którym chcesz wyszukać książkę ma następujące ID: {bookID}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Book foundBook = Library.GetBookRepository().FindBookByID(bookID);
                    if (foundBook == null)
                    {
                        Log.PrintErrorMessage("Niestety nie ma książki o takim ID.");
                    }
                    else
                    {
                        Log.PrintSuccessMessage($"Gratulację! Udało ci się wyszukać książkę o ID {bookID}");
                        Console.WriteLine(foundBook);
                        Console.WriteLine("");
                    }
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
