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
        public void searchByAuthorMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię autora: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaje nazwisko autora: ");
                string surname = Console.ReadLine();
                string authorData = name + " " + surname;
                Console.WriteLine($"Czy autor, po którym chcesz wyszukać książkę ma następujące dane: {authorData}");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                char userOption = char.Parse(Console.ReadLine());
                if (userOption == 'y')
                {
                    Console.WriteLine($"Gratulację! Udało ci się wyszukać dzieło/dzieła autora {authorData}");
                    List<Book> allBooks = library.getAllBooks();
                    bool isAvailable = false;

                    foreach (var book in allBooks)
                    {
                        if (book.getAuthor().Contains(authorData))
                        {
                            Console.WriteLine(book);
                            isAvailable = true;
                        }
                    }
                    if (isAvailable == false)
                    {
                        Console.WriteLine("Niestety nie ma książki napisanej przez takiego autora.");
                    }
                    break;
                }
                else if (userOption == 'n')
                {
                    searchByAuthorMenu();
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
