using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowABookMenu
    {
        Library library;
        public BorrowABookMenu(Library library)
        {
            this.library = library;
        }

        public void borrowBookMenu()
        {
            Console.WriteLine("Podaj swój identyfikator:");
            int userID = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ID książki");
            int ID = int.Parse(Console.ReadLine());
            List<Book> allBooks = library.getAllBooks();
            List<Reader> readers = library.getReaders();

            foreach (var book in allBooks)
            {
                if (book.getID() == ID)
                {
                    Console.WriteLine("Książka znaleziona");
                    foreach (var reader in readers)
                    {
                        if (reader.getID() == userID)
                        {
                            library.borrowBook(book, reader);
                            Console.WriteLine($"Gratulację {reader}, właśnie wypożyczyłeś książkę {book}");
                        }
                    }
                }
            }
        }
    }
}
