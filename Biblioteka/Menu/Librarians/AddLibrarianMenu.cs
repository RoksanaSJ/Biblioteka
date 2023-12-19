using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Librarians
{
    internal class AddLibrarianMenu : Menu
    {
        public AddLibrarianMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Podaj nazwisko:");
                string surname = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Podaj wiek:");
                int age = readOption();
                Console.WriteLine("");

                Console.WriteLine($"Czy pracownik, którego chcesz dodać ma następujące dane: {name} {surname}, wiek: {age}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                   Librarian librarian = new Librarian(name, surname, age);
                    library.addEmployee(librarian);
                    printSuccessMessage($"Gratulację! Udało ci się dodać pracownika: {name} {surname}, wiek: {age}");
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
                else
                {
                    printErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
