using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Menu.Books;
using Biblioteka.Menu.Borrowing;
using Biblioteka.Menu.ImportOrExportData;
using Biblioteka.Menu.Librarians;
using Biblioteka.Menu.Readers;

namespace Biblioteka.Menu.Books
{
    internal class LibraryMenu : Menu
    {
        private BooksMenu _booksMenu;
        private ReaderMenu _readerMenu;
        private BorrowingBookMenu _borrowingBookMenu;
        private ImportExportMenu _importExportMenu;
        private LibrarianMenu _librarianMenu;
        public LibraryMenu(Library library) : base(library)
        {
            _booksMenu = new BooksMenu(library);
            _readerMenu = new ReaderMenu(library);
            _borrowingBookMenu = new BorrowingBookMenu(library);
            _importExportMenu = new ImportExportMenu(library);
            _librarianMenu = new LibrarianMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Menu książek");
                Console.WriteLine("2.Menu czytelników");
                Console.WriteLine("3.Menu wypożyczenia");
                Console.WriteLine("4.Menu pracownika");
                Console.WriteLine("5.Import/Eksport danych");
                Console.WriteLine("6.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = ReadOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    _booksMenu.PrintMenu();
                }
                else if (option == 2)
                {
                    _readerMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    _borrowingBookMenu.PrintMenu();
                    Console.WriteLine("");
                }
                else if (option == 4)
                {
                    _librarianMenu.PrintMenu();
                }
                else if (option == 5)
                {
                    _importExportMenu.PrintMenu();
                }
                else if (option == 6)
                {
                    Environment.Exit(1);
                }
                else
                {
                    PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}

