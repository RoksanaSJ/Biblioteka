using Biblioteka.Model;
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
                Console.WriteLine("Podaj datę urodzenia w formacie yyyy-MM-dd");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                DateTime today = DateTime.Today;
                TimeSpan timeSpan = new TimeSpan();
                timeSpan = today - dateOfBirth;
                int age = today.Year - dateOfBirth.Year;
                if (dateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                } else
                {
                    age = today.Year - dateOfBirth.Year;
                }
                Console.WriteLine("Podaj adres email:");
                string email = Console.ReadLine();
                Console.WriteLine("Podaj hasło:");
                string password = Console.ReadLine();
                Console.WriteLine("Powtórz hasło:");
                string repeatedPassword = Console.ReadLine();
                if (IsEmailCompatible(email) == true) 
                { 
                    if (password.Equals(repeatedPassword))
                    {
                        if (ValidateComplexityPassword(password) == true)
                        {
                            User newUser = new User(email, password, UserRole.Reader);
                            Reader reader = new Reader(name, surname, age, newUser);
                            Library.AddUser(newUser);
                            Library.AddReader(reader);
                            Log.PrintSuccessMessage("Gratulację! utworzyłeś profil nowego użytkownika!");
                        }
                        else
                        {
                            Log.PrintErrorMessage("Hasło musi mieć: conajmniej 8 znaków, conajmniej 1 znak specjalny, mała i dużą literę oraz liczbę");
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
        public bool ValidateComplexityPassword(string password)
        {
            string specialChars = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChar = specialChars.ToCharArray();
            string digits = "123456789";
            char[] digitsChar = digits.ToCharArray();
            bool isContainSpecialChar = false;
            bool isContainDigits = false;
            foreach(char ch in specialChar)
            {
                if(password.Contains(ch))
                {
                    isContainSpecialChar = true;
                }
            }
            foreach(char ch in digitsChar)
            {
                if(password.Contains(ch))
                {
                    isContainDigits = true;
                }
            }
            if (password.Length>=8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && !password.Contains(" ") && isContainSpecialChar == true && isContainDigits == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateUniqnessEmail(string email)
        {
            if (!Library.GetUsersEmail().Contains(email))
            {
                return true;
            }
            else
            {
            Log.PrintErrorMessage("Ten adrea email jest już przypisany do konta");
            return false;
            }
        }
        public bool IsContainAt(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            else
            {
            Log.PrintErrorMessage("Podaj właściwy adres email");
            return false;
            }
        }
        public bool IsEmailCompatible(string email)
        {
            if(ValidateUniqnessEmail(email) == true && IsContainAt(email) == true)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
