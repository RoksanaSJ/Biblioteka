using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class AddBookMenu
    {
        Library library;
        public AddBookMenu(Library library)
        {
            this.library = library;
        }
        public void addBookMenu()
        {
            Console.WriteLine("Podaj tytuł");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj imię autora");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora");
            string surname = Console.ReadLine();

            Book book = new Book(name, surname, title);
            library.addBook(book);
        }
    }
}
