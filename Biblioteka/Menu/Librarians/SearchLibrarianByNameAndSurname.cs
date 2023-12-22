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
        public override void PrintMenu()
        {
            Console.WriteLine("Podaj dane, po których chcesz szukać pracownika");
            Console.WriteLine("Podaj imię:");
            string name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Podaj nazwisko");
            string surname = Console.ReadLine();
            Console.WriteLine("");

            List<Librarian> librarians = Library.GetLiblarians();
            bool isItEqual = false;
            foreach(Librarian librarian in librarians)
            {
                if(librarian.GetName().Equals(name) && librarian.GetSurname().Equals(surname))
                {
                    Log.PrintInformationMessage($"{librarian}");
                    Console.WriteLine("");
                    isItEqual = true;
                }
            }
            if(isItEqual == false) 
            {
                Log.PrintErrorMessage("Nie ma pracownika o takim imieniu i nazwisku");
            }
        }
    }
}
