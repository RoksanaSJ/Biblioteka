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
    internal class LibraryMenuForReader : Menu
    {
        private SearchBookMenu _searchBookMenu;
        private ReaderInformation _readerInformation;
        private BorrowABookMenu _borrowABookMenu;
        private ReturnABookMenu _returnABookMenu;
        private SubmitBookLoan _submitBookLoan;
        public LibraryMenuForReader(Library library) : base(library)
        {
            _searchBookMenu = new SearchBookMenu(library);
            _readerInformation = new ReaderInformation(library);
            _borrowABookMenu = new BorrowABookMenu(library);
            _returnABookMenu = new ReturnABookMenu(library);
            _submitBookLoan = new SubmitBookLoan(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                User currentUser = Library.GetUserRepository().GetCurrentUser();
                Log.PrintCurrentUserMessage("Zalogowano jako: " + currentUser.GetEmail());
                Console.WriteLine("1.Moje konto");
                Console.WriteLine("2.Wyszukaj książkę");
                Console.WriteLine("3.Wypisz wszystkie książki");
                Console.WriteLine("4.Wypożycz książkę");
                Console.WriteLine("5.Zwróć książkę");
                Console.WriteLine("6.Przedłóż wypożyczenie");
                Console.WriteLine("7.Wyloguj");
                Console.WriteLine("8.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = ReadOption();
                if (option == 1)
                {
                    _readerInformation.PrintMenuForCurrentUser();
                }
                else if (option == 2)
                {
                    _searchBookMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    Log.PrintInformationMessage("Lista książek:");
                    Library.GetBookRepository().PrintList();
                }
                else if (option == 4)
                {
                    _borrowABookMenu.PrintMenu();
                }
                else if (option == 5)
                {
                    _returnABookMenu.PrintMenu();
                }
                else if (option == 6)
                {
                    _submitBookLoan.PrintMenu();
                }
                else if (option == 7)
                {
                    break;
                }
                else if (option == 8)
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
