using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteka.Model.Book;


namespace Biblioteka.Menu.Borrowings
{
    internal class BorrowingBookMenu :Menu
    {
        private BorrowABookMenu _borrowABookMenu;
        private ReturnABookMenu _returnABookMenu;
        private SubmitBookLoan _submitBookLoan;
        public BorrowingBookMenu(Library library) : base(library)
        {
            _borrowABookMenu = new BorrowABookMenu(library);
            _returnABookMenu = new ReturnABookMenu(library);
            _submitBookLoan = new SubmitBookLoan(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wypożycz książkę");
                Console.WriteLine("2.Oddaj książkę");
                Console.WriteLine("3.Przedłóż swoje wypożyczenie");
                Console.WriteLine("4.Wypisz wszystkie wypożyczenia");
                Console.WriteLine("5.Wypisz wszystkie zwroty");
                Console.WriteLine("6.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                if (option == 1)
                {
                    _borrowABookMenu.PrintMenu();
                } else if (option == 2)
                {
                    _returnABookMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    _submitBookLoan.PrintMenu();
                } else if (option == 4)
                {
                    Log.PrintInformationMessage("Lista wypożyczeń: ");
                    Library.GetBorrowingRepository().ListTheBorrowings();
                }
                else if (option == 5)
                {
                    Log.PrintInformationMessage("Lista zwrotów: ");
                    Library.ListTheReturnings();
                }
                else if (option == 6)
                {
                    break;
                }
                else 
                {
                    Log.PrintErrorMessage("Podaj właściwą opcję!");
                }
            }
        }
    }
}
