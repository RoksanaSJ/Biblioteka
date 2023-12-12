using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchBookMenu : Menu
    {
        private SearchByAuthorMenu searchByAuthorMenu;
        private SearchByTitleMenu searchByTitleMenu;
        private SearchByID searchByID;
        public SearchBookMenu(Library library) : base(library)
        {
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            searchByID = new SearchByID(library);
        }

        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wyszukaj po autorze");
                Console.WriteLine("2.Wyszukacj po tytule");
                Console.WriteLine("3.Wyszukaj po ID");
                Console.WriteLine("4. Wróć");
                Console.WriteLine("Podaj opcję: ");
                int choose = readOption();
                if (choose == 1)
                {
                    searchByAuthorMenu.printMenu();
                }
                else if (choose == 2)
                {
                    searchByTitleMenu.printMenu();
                }
                else if (choose == 3)
                {
                    searchByID.printMenu();
                }
                else if (choose == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
            Console.WriteLine("");
        }
        public int readOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch (Exception e)
            {
                int overflow = 9999;
                return overflow;
            }
        }
    }
}
