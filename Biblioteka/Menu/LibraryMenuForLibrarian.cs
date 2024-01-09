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
        private ImportExportMenu _importExportMenu;
        private LibrarianMenu _librarianMenu;
        private ChargeMenu _chargeMenu;
        public LibraryMenuForLibrarian(Library library) : base(library)
        {
            _booksMenu = new BooksMenu(library);
            _readerMenu = new ReaderMenu(library);
            _borrowingBookMenu = new BorrowingBookMenu(library);
            _importExportMenu = new ImportExportMenu(library);
            _librarianMenu = new LibrarianMenu(library);
            _chargeMenu = new ChargeMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                User currentUser = Library.GetCurrentUser();
                Log.PrintCurrentUserMessage("Zalogowano jako: " + currentUser.GetEmail());
                Console.WriteLine("1.Konto pracowinia");
                Console.WriteLine("2.Menu książek");
                Console.WriteLine("3.Menu czytelników");
                Console.WriteLine("4.Menu wypożyczenia");
                Console.WriteLine("5.Menu opłat");
                Console.WriteLine("6.Wyloguj");
                Console.WriteLine("7.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = ReadOption();
                Console.WriteLine("");
                if(option == 1)
                {
                    //TODO
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
                    Console.WriteLine("");
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
