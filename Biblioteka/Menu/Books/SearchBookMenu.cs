using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchBookMenu
    {
        Library library;
        SearchByAuthorMenu searchByAuthorMenu;
        SearchByTitleMenu searchByTitleMenu;
        BooksMenu booksMenu;
        public SearchBookMenu(Library library)
        {
            this.library = library;
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            booksMenu = new BooksMenu(library);
        }

        public void searchingBookMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wyszukaj po autorze");
                Console.WriteLine("2.Wyszukacj po tytule");
                Console.WriteLine("Podaj opcję: ");
                int choose = booksMenu.readOption();
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
        }
    }
}
