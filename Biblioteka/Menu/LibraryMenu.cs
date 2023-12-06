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
        BooksMenu BooksMenu;
        ReaderMenu readerMenu;
        BorrowingBookMenu borrowingBookMenu;
        public LibraryMenu(Library library) : base(library)
        {
            BooksMenu = new BooksMenu(library);
            readerMenu = new ReaderMenu(library);
            borrowingBookMenu = new BorrowingBookMenu(library);
        }
        public void printLibraryMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Menu książek");
                Console.WriteLine("2.Menu czytelników");
                Console.WriteLine("3.Menu wypożyczenia");
                Console.WriteLine("4.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                int option = readOption();

                if (option == 1)
                {
                    BooksMenu.printBooksMenu();
                }
                else if (option == 2)
                {
                    readerMenu.printReaderMenu();
                }
                else if (option == 3)
                {
                    borrowingBookMenu.printBorrowingBookMenu();
                }
                else if (option == 4)
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
        }
        public int readOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch (Exception e)
            {
                int overflow = 9999;
                return overflow;
            }
        }
    }
}

