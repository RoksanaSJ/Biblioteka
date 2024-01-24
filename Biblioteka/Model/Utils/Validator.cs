using Biblioteka.ConsoleMessage;
using Biblioteka.Menu.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model.Utils
{
    internal class Validator
    {
        private Library _library;
        private ConsoleLog _log;
        public Validator() 
        {
            _library = new Library();
            _log = new ConsoleLog();
        }
        public bool ValidateComplexityPassword(string password)
        {
            string specialChars = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChar = specialChars.ToCharArray();
            string digits = "123456789";
            char[] digitsChar = digits.ToCharArray();
            bool isContainSpecialChar = false;
            bool isContainDigits = false;
            foreach (char ch in specialChar)
            {
                if (password.Contains(ch))
                {
                    isContainSpecialChar = true;
                }
            }
            foreach (char ch in digitsChar)
            {
                if (password.Contains(ch))
                {
                    isContainDigits = true;
                }
            }
            if (password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && !password.Contains(" ") && isContainSpecialChar == true && isContainDigits == true)
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
            if (!_library.GetUserRepository().GetUsersEmails().Contains(email))
            {
                return true;
            }
            else
            {
                _log.PrintErrorMessage("Ten adres email jest już przypisany do konta");
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
                _log.PrintErrorMessage("Podaj właściwy adres email");
                return false;
            }
        }
        public bool IsEmailCompatible(string email)
        {
            if (ValidateUniqnessEmail(email) == true && IsContainAt(email) == true)
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
