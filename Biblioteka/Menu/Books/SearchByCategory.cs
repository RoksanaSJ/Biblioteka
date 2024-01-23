using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchByCategory : Menu
    {
        public SearchByCategory(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj kategorie: ");
                string category = Console.ReadLine();
                Console.WriteLine($"\nCzy kategoria, po którym chcesz wyszukać książkę ma następujące dane: {category}?");
                Console.WriteLine("\nJeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    List<Book> oneCategoryBooksList = Library.GetBookRepository().FindBooksByCategory(category);
                    foreach (Book book in oneCategoryBooksList)
                    {
                        Console.WriteLine(book);
                    }
                    if(oneCategoryBooksList.Count == 0)
                    {
                        Log.PrintErrorMessage("Niestety nie ma książek w takiej kategorii");
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
