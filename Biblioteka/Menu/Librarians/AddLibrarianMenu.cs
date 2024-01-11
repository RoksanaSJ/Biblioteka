using Biblioteka.Model;
using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class AddLibrarianMenu : Menu
    {
        public AddLibrarianMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                Console.WriteLine("\nPodaj nazwisko:");
                string surname = Console.ReadLine();
                Console.WriteLine("\nPodaj wiek:");
                int age = ReadOption();
                Console.WriteLine("\nPodaj adres email:");
                string email = Console.ReadLine();
                Console.WriteLine($"Czy pracownik, którego chcesz dodać ma następujące dane: {name} {surname}, wiek: {age}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    string temporaryPassword = PasswordGenerator.GenerateSimplePassword();
                    User user = new User(email,temporaryPassword,UserRole.Librarian);
                    user.SetIfPasswordIsNeededToBeChanged();
                    Librarian librarian = new Librarian(name, surname, age,user);
                    Library.AddUser(user);
                    Log.PrintSuccessMessage($"Gratulację! Udało ci się dodać pracownika: {name} {surname}, wiek: {age}");
                    Log.PrintInformationMessage("\nTymczasowe hasło dla użytkownika, to: " + temporaryPassword);
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
