using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class BooksMenu :Menu
    {
        private AddBookMenu _addBookMenu;
        private RemoveBookMenu _removeBookMenu;
        private SearchBookMenu _searchBookMenu;
        public BooksMenu(Library library) : base(library)
        {
            _addBookMenu = new AddBookMenu(library);
            _removeBookMenu = new RemoveBookMenu(library);
            _searchBookMenu = new SearchBookMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj ksiażkę");
                Console.WriteLine("2.Usuń książkę");
                Console.WriteLine("3.Wyszukaj książkę");
                Console.WriteLine("4.Wypisz wszystkie książki");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("\nWpisz opcje: ");
                int option = ReadOption();
                if (option == 1)
                {
                    _addBookMenu.PrintMenu();
                }
                else if (option == 2)
                {
                    _removeBookMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    _searchBookMenu.PrintMenu();
                }
                else if (option == 4)
                {
                    Log.PrintInformationMessage("Lista książek:");
                    Library.GetBookRepository().PrintList();
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną wartość!");
                }
            }
        }
    }
}
