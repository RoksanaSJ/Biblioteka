using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class BooksMenu :Menu
    {
        private AddBookMenu addBookMenu;
        private SearchByTitleMenu searchByTitleMenu;
        private SearchByAuthorMenu searchByAuthorMenu;
        private RemoveBookMenu removeBookMenu;
        private SearchBookMenu searchBookMenu;
        public BooksMenu(Library library) : base(library)
        {
            addBookMenu = new AddBookMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            removeBookMenu = new RemoveBookMenu(library);
            searchBookMenu = new SearchBookMenu(library);
        }

        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj ksiażkę");
                Console.WriteLine("2.Usuń książkę");
                Console.WriteLine("3.Wyszukaj książkę");
                Console.WriteLine("4.Wypisz wszystkie książki");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Wpisz opcje: ");
                int option = readOption();
                        if (option == 1)
                        {
                            addBookMenu.printMenu();
                        }
                        else if (option == 2)
                        {
                            removeBookMenu.printMenu();
                        }
                        else if (option == 3)
                        {
                            searchBookMenu.printMenu();
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
            Console.WriteLine(" ");
        }
    }
}
