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

        public override void printMenu()
        {
            Console.WriteLine("Podaj ID, po którym chcesz wyszukać pracownika:");
            int ID = readOption();
            Console.WriteLine("");
            List<Librarian> librarians = library.getLiblarians();
            bool isItEqual = false;
            foreach(Librarian librarian in librarians)
            {
                if ((librarian.getID() == ID))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(librarian);
                    Console.ResetColor();
                    Console.WriteLine("");
                    isItEqual = true;
                }
            }
            if(isItEqual == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma pracownika o takim ID");
                Console.ResetColor();
            }
        }
    }
}
