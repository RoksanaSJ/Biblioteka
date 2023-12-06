using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class BooksMenu :Menu
    {
        AddBookMenu addBookMenu;
        SearchByTitleMenu searchByTitleMenu;
        SearchByAuthorMenu searchByAuthorMenu;
        RemoveBookMenu removeBookMenu;
        SearchBookMenu searchBookMenu;
        public BooksMenu(Library library) : base(library)
        {
            addBookMenu = new AddBookMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            removeBookMenu = new RemoveBookMenu(library);
            searchBookMenu = new SearchBookMenu(library);
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
                int option = readOption();
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
                            searchBookMenu.searchingBookMenu();
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
        public int readOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch(Exception e)
            {
                int overflow = 9999;
                return overflow;
            }
        }
    }
}
