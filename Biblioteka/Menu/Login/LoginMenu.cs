using Biblioteka.Menu.Books;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Biblioteka.Menu.Login
{
    internal class LoginMenu : Menu
    {
        private LibraryMenu _libraryMenu;
        private LibraryMenuForReader _libraryMenuForReader;
        public LoginMenu(Library library) : base(library)
        {
            _libraryMenu = new LibraryMenu(library);
            _libraryMenuForReader = new LibraryMenuForReader(library);
        }

        public override void PrintMenu()
        {
            Console.WriteLine("Podaj swój adres email:");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Podaj swoje hasło:");
            string userPassword = Console.ReadLine();
            List<User> tempUsersList = Library.GetUsers();
            bool isEqual = false;
            foreach (User user in tempUsersList)
            {
                if (user.GetEmail().Equals(userEmail) && user.GetPassword().Equals(userPassword))
                {
                    Library.SetCurrentUser(user);
                    if(user.GetUserRole() == UserRole.Administrator)
                    {
                        _libraryMenu.PrintMenu();
                    }
                    else if(user.GetUserRole()== UserRole.Librarian) 
                    {
                    
                    }
                    else
                    {
                        _libraryMenuForReader.PrintMenu();
                    }
                    isEqual = true;
                }
            }
            if (isEqual == false)
            {
                Console.WriteLine("Niestety twoje dane są niepoprawne");
            }
        }
    }
}
