using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class SearchByAuthorMenu : Menu
    {
        public SearchByAuthorMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię autora: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaje nazwisko autora: ");
                string surname = Console.ReadLine();
                string fullName = name + " " + surname;
                Console.WriteLine($"\nCzy autor, po którym chcesz wyszukać książkę ma następujące dane: {fullName}?");
                Console.WriteLine("\nJeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    List<Book> oneAuthorBooks = Library.GetBookRepository().FindBooksByAuthor(fullName);
                    foreach (Book book in oneAuthorBooks)
                    {
                        Console.WriteLine(book);
                    }
                    if(oneAuthorBooks.Count == 0) 
                    {
                        Log.PrintErrorMessage("Niestety nie ma książek należących do tego autora");
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
