using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteka.Model.Book;


namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowingBookMenu :Menu
    {
        BorrowABookMenu borrowABookMenu;
        ReturnABookMenu returnABookMenu;
        public BorrowingBookMenu(Library library) : base(library)
        {
            borrowABookMenu = new BorrowABookMenu(library);
            returnABookMenu = new ReturnABookMenu(library);
        }
        public void printMenu()
        {
            Console.WriteLine("1.Wypożycz książkę");
            Console.WriteLine("2.Oddaj książkę");
            Console.WriteLine("3.Wypisz wszystkie wypożyczenia");
            Console.WriteLine("Podaj opcję: ");
            int option = readOption();
                    switch (option)
                    {
                        case 1:
                            borrowABookMenu.borrowBookMenu();
                            break;
                        case 2:
                            returnABookMenu.returnABookMenu();
                            break;
                        default:
                            Console.WriteLine("Podaj właściwą opcję!");
                            break;
                    }
            Console.WriteLine(" ");
        }
    }
}
