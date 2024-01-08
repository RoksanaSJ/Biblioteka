using Biblioteka.Menu.Login;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Entry
{
    internal class EntryMenu : Menu
    {
        private LoginMenu _loginMenu;
        private NewUserMenu _newUserMenu;
        public EntryMenu(Library library) : base(library)
        {
            _loginMenu = new LoginMenu(library);
            _newUserMenu = new NewUserMenu(library);
        }

        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Logowanie");
                Console.WriteLine("2. Rejestracja");
                Console.WriteLine("Podaj opcję:");
                int userOption = ReadOption();
                if(userOption == 1)
                {
                    _loginMenu.PrintMenu();
                }
                else if (userOption == 2)
                {
                    _newUserMenu.PrintMenu();
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
