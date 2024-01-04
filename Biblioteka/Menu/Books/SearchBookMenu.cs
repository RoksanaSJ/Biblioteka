using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchBookMenu : Menu
    {
        private SearchByAuthorMenu _searchByAuthorMenu;
        private SearchByTitleMenu _searchByTitleMenu;
        private SearchByID _searchByID;
        private SearchByCategory _searchByCategory;
        public SearchBookMenu(Library library) : base(library)
        {
            _searchByAuthorMenu = new SearchByAuthorMenu(library);
            _searchByTitleMenu = new SearchByTitleMenu(library);
            _searchByID = new SearchByID(library);
            _searchByCategory = new SearchByCategory(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wyszukaj po autorze");
                Console.WriteLine("2.Wyszukaj po tytule");
                Console.WriteLine("3.Wyszukaj po ID");
                Console.WriteLine("4.Wyszukaj po kategorii");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int choose = ReadOption();
                Console.WriteLine("");
                if (choose == 1)
                {
                    _searchByAuthorMenu.PrintMenu();
                }
                else if (choose == 2)
                {
                    _searchByTitleMenu.PrintMenu();
                }
                else if (choose == 3)
                {
                    _searchByID.PrintMenu();
                }
                else if (choose == 4)
                {
                    _searchByCategory.PrintMenu();
                }
                else if (choose == 5)
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
