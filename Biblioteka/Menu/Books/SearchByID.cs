using Biblioteka.Model;
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
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID książki: ");
                int booksID = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine($"Czy ID, po którym chcesz wyszukać książkę ma następujące ID: {booksID}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = library.getAllBooks();
                    bool isAvailable = false;
                    foreach (var book in allBooks)
                    {
                        if (book.getID() == booksID)
                        {
                            printSuccessMessage($"Gratulację! Udało ci się wyszukać książkę o ID {booksID}");
                            Console.WriteLine(book);
                            Console.WriteLine("");
                            isAvailable = true;
                        }
                    }
                    if (isAvailable == false)
                    {
                        printErrorMessage("Niestety nie ma książki o takim ID.");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    printMenu();
                    Console.WriteLine("");
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    printErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
