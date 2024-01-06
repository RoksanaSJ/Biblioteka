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
            while (true)
            {
                Console.WriteLine("Podaj ID, po którym chcesz wyszukać pracownika:");
                int ID = ReadOption();
                Console.WriteLine("");
                Console.WriteLine($"Czy ID, po którym chcesz wyszukać pracownika ma następujące ID: {ID}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Librarian> librarians = Library.GetLibrarians();
                    bool isItEqual = false;
                    foreach (Librarian librarian in librarians)
                    {
                        if ((librarian.GetID() == ID))
                        {
                            Log.PrintInformationMessage($"{librarian}");
                            isItEqual = true;
                        }
                    }
                    if (isItEqual == false)
                    {
                        Log.PrintErrorMessage("Nie ma pracownika o takim ID");
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
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
