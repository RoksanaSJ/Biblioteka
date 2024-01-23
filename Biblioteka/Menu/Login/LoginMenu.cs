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
        private LibraryMenuForAdmin _libraryMenuForAdmin;
        private LibraryMenuForReader _libraryMenuForReader;
        private LibraryMenuForLibrarian _libraryMenuForLibrarian;
        public LoginMenu(Library library) : base(library)
        {
            _libraryMenuForAdmin = new LibraryMenuForAdmin(library);
            _libraryMenuForReader = new LibraryMenuForReader(library);
            _libraryMenuForLibrarian = new LibraryMenuForLibrarian(library);
        }
        public override void PrintMenu()
        {
            Console.WriteLine("Podaj swój adres email:");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Podaj swoje hasło:");
            string userPassword = Console.ReadLine();
            //to co poniżej - osobna metoda w klasie library, lub więcej niż 1 metoda
            List<User> tempUsersList = Library.GetUserRepository().GetUsers();
            bool isEqual = false;
            bool isAdmin = false;
            bool isLibrarian = false;
            bool isReader = false;
            foreach (User user in tempUsersList)
            {
                if (user.GetEmail().Equals(userEmail) && user.GetPassword().Equals(userPassword))
                {
                    Library.GetUserRepository().SetCurrentUser(user);
                    if (user.GetUserRole() == UserRole.Administrator)
                    {
                        isAdmin = true;
                    }
                    else if (user.GetUserRole() == UserRole.Librarian)
                    {
                        isLibrarian = true;
                        if(user.GetInfoAboutPassword() == true)
                        {
                            Log.PrintInformationMessage("Musisz zmienic hasło");
                            Console.WriteLine("Podaj nowe hasło:");
                            string newPassword = Console.ReadLine();
                            Console.WriteLine("Powtórz nowe hasło:");
                            string repeatedNewPassword = Console.ReadLine();
                            if(repeatedNewPassword == newPassword) 
                            {
                                user.SetPassword(repeatedNewPassword);
                                user.SetIfPasswordIsNotNeededToBeChanged();
                                Log.PrintSuccessMessage("Garatulację, właśnie zmieniłeś hasło!");
                            }
                            else
                            {
                                Log.PrintErrorMessage("Hasła muszą być takie same!");
                            }
                        }
                    }
                    else if (user.GetUserRole() == UserRole.Reader)
                    {
                        isReader = true;
                    }
                    isEqual = true;
                }
            }
            if (isEqual == false)
            {
                Log.PrintErrorMessage("Niestety twoje dane są niepoprawne");
            }
            if (isAdmin == true)
            {
                _libraryMenuForAdmin.PrintMenu();
            }
            else if (isLibrarian == true)
            { 
                _libraryMenuForLibrarian.PrintMenu();
            }
            else if (isReader == true)
            {
                _libraryMenuForReader.PrintMenu();
            }
        }
    }
}
