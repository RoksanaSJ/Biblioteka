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
                Console.WriteLine($"Czy ID, po którym chcesz wyszukać książkę ma następujące dane: {booksID}");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = library.getAllBooks();
                    bool isAvailable = false;
                    foreach (var book in allBooks)
                    {
                        if (book.getID() == booksID)
                        {
                            Console.WriteLine($"Gratulację! Udało ci się wyszukać książkę o ID {booksID}");
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
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
            Console.WriteLine(" ");
        }
    }
}
