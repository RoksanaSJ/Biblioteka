using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Menu.Books;
using Biblioteka.Menu.Borrowing;
using Biblioteka.Menu.Readers;

namespace Biblioteka.Menu.Books
{
    internal class LibraryMenu : Menu
    {
        private BooksMenu BooksMenu;
        private ReaderMenu readerMenu;
        private BorrowingBookMenu borrowingBookMenu;
        public LibraryMenu(Library library) : base(library)
        {
            BooksMenu = new BooksMenu(library);
            readerMenu = new ReaderMenu(library);
            borrowingBookMenu = new BorrowingBookMenu(library);
        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Menu książek");
                Console.WriteLine("2.Menu czytelników");
                Console.WriteLine("3.Menu wypożyczenia");
                Console.WriteLine("4.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = readOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    BooksMenu.printMenu();
                }
                else if (option == 2)
                {
                    readerMenu.printMenu();
                }
                else if (option == 3)
                {
                    borrowingBookMenu.printMenu();
                    Console.WriteLine("");
                }
                else if (option == 4)
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaj poprawną opcję!");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
        }
    }
}

