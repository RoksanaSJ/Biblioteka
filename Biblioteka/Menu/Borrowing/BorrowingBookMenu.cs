using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteka.Book;


namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowingBookMenu
    {
        Library library;
        BorrowABookMenu borrowABookMenu;
        public BorrowingBookMenu(Library library)
        {
            this.library = library;
            borrowABookMenu = new BorrowABookMenu(library);
        }

        public void printBorrowingBookMenu()
        {
            Console.WriteLine("1.Wypożycz książkę");
            Console.WriteLine("2.Oddaj książkę");
            Console.WriteLine("3.Wypisz wszystkie wypożyczenia");
            Console.WriteLine("Podaj opcję: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    borrowABookMenu.borrowBookMenu();
                    break;
                case 2:
                    Console.WriteLine("Podaj tytuł książki");
                    string returningTitle = Console.ReadLine();
                    List<Book> books = library.getAllBooks();
                    foreach (var book in books)
                        if (book.getTitle().Contains(returningTitle))
                        {
                            //  library.
                        }
                    break;
                default:
                    Console.WriteLine("Podaj właściwą opcję1");
                    break;
            }
        }
    }
}
