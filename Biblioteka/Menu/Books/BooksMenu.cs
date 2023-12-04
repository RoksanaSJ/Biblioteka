using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Book
{
    internal class BooksMenu
    {
        Library library;
        AddBookMenu addBookMenu;
        SearchByTitleMenu searchByTitleMenu;
        SearchByAuthorMenu searchByAuthorMenu;
        RemoveBookMenu removeBookMenu;
        public BooksMenu(Library library)
        {
            this.library = library;
            addBookMenu = new AddBookMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            removeBookMenu = new RemoveBookMenu(library);
        }

        public void printBooksMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj ksiażkę");
                Console.WriteLine("2.Usuń książkę");
                Console.WriteLine("3.Wyszukaj książkę");
                Console.WriteLine("4.Wypisz wszystkie książki");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Wpisz opcje: ");

                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    addBookMenu.addBookMenu();
                }
                else if (option == 2)
                {
                    removeBookMenu.removeBookMenu();
                }
                else if (option == 3)
                {
                    Console.WriteLine("1.Wyszukaj po autorze");
                    Console.WriteLine("2.Wyszukacj po tytule");
                    Console.WriteLine("Podaj opcję: ");
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            searchByAuthorMenu.searchByAuthorMenu();
                            break;
                        case 2:
                            searchByTitleMenu.searchByTitleMenu();
                            break;
                        default:
                            Console.WriteLine("Podaj poprawną opcję!");
                            break;
                    }
                }
                else if (option == 4)
                {
                    Console.WriteLine("Lista książek:");
                    library.listTheBooks();
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna wartość");

                }
            }
        }
    }
}
