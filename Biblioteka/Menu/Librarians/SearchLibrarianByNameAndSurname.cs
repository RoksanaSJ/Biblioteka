using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class SearchLibrarianByNameAndSurname : Menu
    {
        public SearchLibrarianByNameAndSurname(Library library) : base(library)
        {
        
        }
        public override void printMenu()
        {
            Console.WriteLine("Podaj dane, po których chcesz szukać pracownika");
            Console.WriteLine("Podaj imię:");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Podaj nazwisko");
            string surname = Console.ReadLine();
            Console.WriteLine("");

            List<Librarian> librarians = library.getLiblarians();
            bool isItEqual = false;
            foreach(Librarian librarian in librarians)
            {
                if(librarian.getName().Equals(name) && librarian.getSurname().Equals(surname))
                {
                    printInformationMessage($"{librarian}");
                    Console.WriteLine("");
                    isItEqual = true;
                }
            }
            if(isItEqual == false) 
            {
                printErrorMessage("Nie ma pracownika o takim imieniu i nazwisku");
            }
        }
    }
}
