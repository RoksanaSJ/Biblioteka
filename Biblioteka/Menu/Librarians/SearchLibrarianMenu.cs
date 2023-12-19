using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class SearchLibrarianMenu : Menu
    {
        private SearchLibrarianByID _searchLibrarianByID;
        private SearchLibrarianByNameAndSurname _searchLibrarianByNameAndSurname;
        public SearchLibrarianMenu(Library library) : base(library)
        {
            _searchLibrarianByID = new SearchLibrarianByID(library);
            _searchLibrarianByNameAndSurname = new SearchLibrarianByNameAndSurname(library);
        }

        public override void PrintMenu()
        {
            Console.WriteLine("1.Wyszukaj po imieniu i nazwisku");
            Console.WriteLine("2.Wyszukaj po ID");
            Console.WriteLine("Podaj opcję:");
            int userOption = ReadOption();
            Console.WriteLine(" ");
            if(userOption == 1)
            {
                _searchLibrarianByNameAndSurname.PrintMenu();
            }
            else if(userOption == 2)
            {
                _searchLibrarianByID.PrintMenu();
            }
            else
            {
                PrintErrorMessage("Podaj poprawną opcję!");
            }
        }
    }
}
