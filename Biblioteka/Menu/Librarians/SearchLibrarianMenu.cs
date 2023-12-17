using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class SearchLibrarianMenu : Menu
    {
        SearchLibrarianByID searchLibrarianByID;
        SearchLibrarianByNameAndSurname searchLibrarianByNameAndSurname;
        public SearchLibrarianMenu(Library library) : base(library)
        {
            searchLibrarianByID = new SearchLibrarianByID(library);
            searchLibrarianByNameAndSurname = new SearchLibrarianByNameAndSurname(library);
        }

        public override void printMenu()
        {
            Console.WriteLine("1.Wyszukaj po imieniu i nazwisku");
            Console.WriteLine("2.Wyszukaj po ID");
            Console.WriteLine("Podaj opcję:");
            int userOption = readOption();
            Console.WriteLine(" ");
            if(userOption == 1)
            {
                searchLibrarianByNameAndSurname.printMenu();
            }
            else if(userOption == 2)
            {
                searchLibrarianByID.printMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podaj poprawną opcję!");
                Console.ResetColor();
            }
        }
    }
}
