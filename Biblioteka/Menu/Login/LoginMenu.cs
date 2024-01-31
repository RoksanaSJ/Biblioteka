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
            User user = Library.Login(userEmail, userPassword);
            if (user != null)
            {
                if (user.GetInfoAboutPassword())
                {
                    Log.PrintInformationMessage("Musisz zmienic hasło");
                    Console.WriteLine("Podaj nowe hasło:");
                    string newPassword = Console.ReadLine();
                    Console.WriteLine("Powtórz nowe hasło:");
                    string repeatedNewPassword = Console.ReadLine();
                    if (repeatedNewPassword == newPassword)
                    {
                        user.SetPassword(repeatedNewPassword);
                        Log.PrintSuccessMessage("Garatulację, właśnie zmieniłeś hasło!");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Hasła muszą być takie same!");
                    }
                }
                if (user.GetUserRole() == UserRole.Administrator)
                {
                    _libraryMenuForAdmin.PrintMenu();
                }
                else if (user.GetUserRole() == UserRole.Librarian)
                {
                    _libraryMenuForLibrarian.PrintMenu();
                }
                else if (user.GetUserRole() == UserRole.Reader)
                {
                    _libraryMenuForReader.PrintMenu();
                }
            }
            else
            {
                Log.PrintErrorMessage("Niestety twoje dane są niepoprawne");
            }
        }
    }
}
