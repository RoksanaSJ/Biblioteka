using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Entry
{
    internal class NewUserMenu : Menu
    {
        public NewUserMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko:");
                string surname = Console.ReadLine();
                //Kiedyś zmienić na datę urodzenia
                Console.WriteLine("Podaj wiek:");
                int age = ReadOption();
                Console.WriteLine("Podaj adres email:");
                string email = Console.ReadLine();
                Console.WriteLine("Podaj hasło:");
                string password = Console.ReadLine();
                Console.WriteLine("Powtórz hasło:");
                string repeatedPassword = Console.ReadLine();
                if (password.Equals(repeatedPassword))
                {
                    //metoda na sprawdzenie, czy hasło jest silne, min 8 znaków, 1 znak specjalny, liczba, mała i duża litera
                    //czy adres email jest unikalny -osobna metoda
                    if(ValidateComplexityPassword(password) == true)
                    {
                        User newUser = new User(email, password,UserRole.Reader);
                        Reader reader = new Reader(name, surname, age, newUser);
                        Library.AddUser(newUser);
                        Library.AddReader(reader);
                        Log.PrintSuccessMessage("Gratulację! utworzyłeś profil nowego użytkownika!");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Hasło musi mieć...");
                    }
                }
                else
                {
                    Log.PrintErrorMessage("Podaj takie samo hasło!");
                }
                break;
            }
        }
        //TODO
        public bool ValidateComplexityPassword(string password)
        {
            return true;
        }
        public bool ValidateUniqnessEmail(string email)
        {
            return true;
        }
    }
}
