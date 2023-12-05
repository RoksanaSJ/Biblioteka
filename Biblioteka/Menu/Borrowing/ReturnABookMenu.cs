using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Borrowing
{
    internal class ReturnABookMenu
    {
        Library library;
        public ReturnABookMenu(Library library)
        {
            this.library = library;
        }

        public void returnABookMenu() 
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
                            library.returnBook(book, reader);
                            Console.WriteLine($"Gratulację {reader}, właśnie oddałeś książkę {book}");
                        }
                    }
                }
            }
        }
    }
}
