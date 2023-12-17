using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class LibrarianMenu : Menu
    {
        AddLibrarianMenu addLibrarianMenu;
        RemoveLibrarianMenu removeLibrarianMenu;
        SearchLibrarianMenu searchLibrarianMenu;
        public LibrarianMenu(Library library) : base(library) 
        { 
        addLibrarianMenu = new AddLibrarianMenu(library);
        removeLibrarianMenu = new RemoveLibrarianMenu(library);
        searchLibrarianMenu = new SearchLibrarianMenu(library);
        }

        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj pracownika");
                Console.WriteLine("2.Usuń pracownika");
                Console.WriteLine("3.Wyszukaj pracownika");
                Console.WriteLine("4.Wypisz wszystkich pracowników");
                Console.WriteLine("Podaj opcję:");
                int option = readOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    addLibrarianMenu.printMenu();
                }
                else if (option == 2)
                {
                    removeLibrarianMenu.printMenu();
                }
                else if (option == 3)
                {
                    searchLibrarianMenu.printMenu();
                }
                else if (option == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Lista pracowników");
                    library.listTheLibrarians();
                    Console.WriteLine("");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaj prawidłową opcję!");
                    Console.ResetColor();
                }
            }

        }
    }
}
