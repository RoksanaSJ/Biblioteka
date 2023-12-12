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
        BorrowABookMenu borrowABookMenu;
        ReturnABookMenu returnABookMenu;
        public BorrowingBookMenu(Library library) : base(library)
        {
            borrowABookMenu = new BorrowABookMenu(library);
            returnABookMenu = new ReturnABookMenu(library);
        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wypożycz książkę");
                Console.WriteLine("2.Oddaj książkę");
                Console.WriteLine("3.Wypisz wszystkie wypożyczenia");
                Console.WriteLine("4.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = readOption();
                if (option == 1)
                {
                    borrowABookMenu.printMenu();
                } else if (option == 2)
                {
                    returnABookMenu.printMenu();
                } else if (option == 3)
                {
                    Console.WriteLine("Lista wypożyczeń: ");
                    library.listTheBorrowings();
                } else if (option == 4)
                {
                    break;
                }
                else 
                { 
                    Console.WriteLine("Podaj właściwą opcję!");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
