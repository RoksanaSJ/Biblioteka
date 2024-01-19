using Biblioteka.Menu.Books;
using Biblioteka.Menu.Borrowings;
using Biblioteka.Menu.Charge;
using Biblioteka.Menu.ImportOrExportData;
using Biblioteka.Menu.Librarians;
using Biblioteka.Menu.Readers;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu
{
    internal class LibraryMenuForLibrarian : Menu
    {
        private BooksMenu _booksMenu;
        private ReaderMenu _readerMenu;
        private BorrowingBookMenu _borrowingBookMenu;
        private ChargeMenu _chargeMenu;
        private LibrarianInformationMenu _librarianInformationMenu;
        public LibraryMenuForLibrarian(Library library) : base(library)
        {
            _booksMenu = new BooksMenu(library);
            _readerMenu = new ReaderMenu(library);
            _borrowingBookMenu = new BorrowingBookMenu(library);
            _chargeMenu = new ChargeMenu(library);
            _librarianInformationMenu = new LibrarianInformationMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                User currentUser = Library.GetCurrentUser();
                Log.PrintCurrentUserMessage("Zalogowano jako: " + currentUser.GetEmail());
                Console.WriteLine("1.Konto pracownika");
                Console.WriteLine("2.Menu książek");
                Console.WriteLine("3.Menu czytelników");
                Console.WriteLine("4.Menu wypożyczenia");
                Console.WriteLine("5.Menu opłat");
                Console.WriteLine("6.Wyloguj");
                Console.WriteLine("7.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = ReadOption();
                if(option == 1)
                {
                    _librarianInformationMenu.PrintMenu();
                }
                else if (option == 2)
                {
                    _booksMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    _readerMenu.PrintMenu();
                }
                else if (option == 4)
                {
                    _borrowingBookMenu.PrintMenu();
                }
                else if (option == 5)
                {
                    _chargeMenu.PrintMenu();
                }
                else if (option == 6)
                {
                    break;
                }
                else if (option == 7)
                {
                    Environment.Exit(1);
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
