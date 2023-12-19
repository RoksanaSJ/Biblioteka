using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class SearchLibrarianByID : Menu
    {
        public SearchLibrarianByID(Library library) : base(library)
        { 
        
        }
        public override void PrintMenu()
        {
            Console.WriteLine("Podaj ID, po którym chcesz wyszukać pracownika:");
            int ID = ReadOption();
            Console.WriteLine("");
            List<Librarian> librarians = Library.GetLiblarians();
            bool isItEqual = false;
            foreach(Librarian librarian in librarians)
            {
                if ((librarian.GetID() == ID))
                {
                    PrintInformationMessage($"{librarian}");
                    isItEqual = true;
                }
            }
            if(isItEqual == false)
            {
                PrintErrorMessage("Nie ma pracownika o takim ID");
            }
        }
    }
}
