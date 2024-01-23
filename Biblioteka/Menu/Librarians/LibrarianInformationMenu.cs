using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class LibrarianInformationMenu : Menu
    {
        public LibrarianInformationMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            List<Librarian> librarians = Library.GetLibrarianRepository().Get();
            User currentUser = Library.GetUserRepository().GetCurrentUser();
            Log.PrintInformationMessage("Dane użytkownika: ");
            foreach (Librarian librarian in librarians)
            {
                if (librarian.GetUser().Equals(currentUser))
                {
                    Console.WriteLine(librarian);
                }
            }
            Console.WriteLine("");
            Console.WriteLine(currentUser);
        }
    }
}
