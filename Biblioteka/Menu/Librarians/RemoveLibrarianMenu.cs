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
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID:");
                int ID = readOption();

                Console.WriteLine($"Czy pracownik, którego chcesz usunąć ma następujące ID: {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Librarian> librarians = library.getLiblarians();
                    List<Librarian> toRemove = new List<Librarian> ();
                    bool isItEqual = false;
                    foreach (Librarian librarian in librarians)
                    {
                        if (librarian.getID() == ID)
                        {
                            toRemove.Add(librarian);
                            isItEqual = true;
                        }
                    }
                        if (isItEqual == false)
                        {
                            printErrorMessage("Nie ma w bazie pracownika o takim ID");
                        }
                        foreach (var employee in toRemove)
                        {
                            librarians.Remove(employee);
                        printSuccessMessage($"Gratulacje, właśnie usunąłeś pracownika {employee.ToString()}");                     
                    }
                        break;
                    }
                else if (userOption.Equals("n"))
                {
                    printMenu();
                    Console.WriteLine(" ");
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
            }
        }
    }
}
