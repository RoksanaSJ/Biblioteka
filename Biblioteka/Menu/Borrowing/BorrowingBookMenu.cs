using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteka.Model.Book;


namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowingBookMenu :Menu
    {
        private BorrowABookMenu _borrowABookMenu;
        private ReturnABookMenu _returnABookMenu;
        public BorrowingBookMenu(Library library) : base(library)
        {
            _borrowABookMenu = new BorrowABookMenu(library);
            _returnABookMenu = new ReturnABookMenu(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wypożycz książkę");
                Console.WriteLine("2.Oddaj książkę");
                Console.WriteLine("3.Wypisz wszystkie wypożyczenia");
                Console.WriteLine("4.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    _borrowABookMenu.PrintMenu();
                } else if (option == 2)
                {
                    _returnABookMenu.PrintMenu();
                } else if (option == 3)
                {
                    PrintInformationMessage("Lista wypożyczeń");
                    Library.ListTheBorrowings();
                    Console.WriteLine("");
                } else if (option == 4)
                {
                    break;
                }
                else 
                {
                    PrintErrorMessage("Podaj właściwą opcję!");
                }
            }
        }
    }
}
