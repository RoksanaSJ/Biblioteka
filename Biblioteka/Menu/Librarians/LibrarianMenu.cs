using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class LibrarianMenu : Menu
    {
        private AddLibrarianMenu _addLibrarianMenu;
        private RemoveLibrarianMenu _removeLibrarianMenu;
        private SearchLibrarianMenu _searchLibrarianMenu;
        public LibrarianMenu(Library library) : base(library) 
        { 
        _addLibrarianMenu = new AddLibrarianMenu(library);
        _removeLibrarianMenu = new RemoveLibrarianMenu(library);
        _searchLibrarianMenu = new SearchLibrarianMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj pracownika");
                Console.WriteLine("2.Usuń pracownika");
                Console.WriteLine("3.Wyszukaj pracownika");
                Console.WriteLine("4.Wypisz wszystkich pracowników");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Podaj opcję:");
                int option = ReadOption();
                if (option == 1)
                {
                    _addLibrarianMenu.PrintMenu();
                }
                else if (option == 2)
                {
                    _removeLibrarianMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    _searchLibrarianMenu.PrintMenu();
                }
                else if (option == 4)
                {
                    Log.PrintInformationMessage($"Lista pracowników: ");
                    Library.ListTheLibrarians();
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj prawidłową opcję!");
                }
            }

        }
    }
}
