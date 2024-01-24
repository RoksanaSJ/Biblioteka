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
            while (true)
            {
                Console.WriteLine("Podaj dane, po których chcesz szukać pracownika");
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko");
                string surname = Console.ReadLine();
                Console.WriteLine($"Czy to są dane, po których chcesz wyszukać pracownika: {name}, {surname}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    Librarian librarian = Library.GetLibrarianRepository().FindLibrarianByFullname(name, surname);
                    if(librarian != null)
                    {
                        Log.PrintInformationMessage(librarian.ToString());
                    }
                    else
                    {
                        Log.PrintErrorMessage("Nie ma pracownika o takim imieniu i nazwisku");
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
