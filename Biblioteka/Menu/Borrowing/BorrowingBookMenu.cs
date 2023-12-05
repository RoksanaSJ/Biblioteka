using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteka.Model.Book;


namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowingBookMenu
    {
        Library library;
        BorrowABookMenu borrowABookMenu;
        ReturnABookMenu returnABookMenu;
        public BorrowingBookMenu(Library library)
        {
            this.library = library;
            borrowABookMenu = new BorrowABookMenu(library);
            returnABookMenu = new ReturnABookMenu(library);
        }

        public void printBorrowingBookMenu()
        {
            Console.WriteLine("1.Wypożycz książkę");
            Console.WriteLine("2.Oddaj książkę");
            Console.WriteLine("3.Wypisz wszystkie wypożyczenia");
            Console.WriteLine("Podaj opcję: ");
            bool isItTrue = true;
            do
            {
                try
                {
                    int option = int.Parse(Console.ReadLine());
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
                }
                catch (Exception e)
                {
                    Console.WriteLine("Aby wybrać opcję musisz podać wartość liczbową 1 lub 2!");
                    isItTrue = false;

                }
            } while (isItTrue == false);
        }
    }
}
