using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class RemoveLibrarianMenu : Menu
    {
        public RemoveLibrarianMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID:");
                int ID = ReadOption();
                Console.WriteLine($"Czy pracownik, którego chcesz usunąć ma następujące ID: {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    Librarian librarian = Library.GetLibrarianRepository().FindLibrarianByID(ID);
                    if (librarian != null)
                    {
                        Library.GetLibrarianRepository().RemoveLibrarian(librarian);
                        Log.PrintSuccessMessage($"Gratulacje, właśnie usunąłeś pracownika {librarian.ToString()}");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Nie ma w bazie pracownika o takim ID");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    continue;
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
            }
        }
    }
}
