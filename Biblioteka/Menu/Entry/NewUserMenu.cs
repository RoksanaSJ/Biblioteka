using Biblioteka.Model;
using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Entry
{
    internal class NewUserMenu : Menu
    {
        private Validator _validator;
        public NewUserMenu(Library library) : base(library)
        {
            _validator = new Validator();
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko:");
                string surname = Console.ReadLine();
                Console.WriteLine("Podaj datę urodzenia w formacie yyyy-MM-dd");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Podaj adres email:");
                string email = Console.ReadLine();
                Console.WriteLine("Podaj hasło:");
                string password = Console.ReadLine();
                Console.WriteLine("Powtórz hasło:");
                string repeatedPassword = Console.ReadLine();
                if (_validator.IsEmailCompatible(email) == true) 
                { 
                    if (password.Equals(repeatedPassword))
                    {
                        if (_validator.ValidateComplexityPassword(password) == true)
                        {
                            Library.CreateReaderAndUser(name, surname, dateOfBirth,email,password);
                            Log.PrintSuccessMessage("\nGratulację! utworzyłeś profil nowego użytkownika!");
                        }
                        else
                        {
                            Log.PrintErrorMessage("Hasło musi mieć: conajmniej 8 znaków, conajmniej 1 znak specjalny, małą i dużą literę oraz liczbę");
                        }
                    }
                    else
                    {
                        Log.PrintErrorMessage("Podaj takie samo hasło!");
                    }
                }
                break;
            }
        }
    }
}
