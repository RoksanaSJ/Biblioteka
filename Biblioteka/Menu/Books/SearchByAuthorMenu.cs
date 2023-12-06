using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class SearchByAuthorMenu : Menu
    {
        public SearchByAuthorMenu(Library library) : base(library)
        {

        }

        public void searchByAuthorMenu()
        {
            Console.WriteLine("Podaj imię autora: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaje nazwisko autora: ");
            string surname = Console.ReadLine();
            string authorData = name + " " + surname;
            List<Book> allBooks = library.getAllBooks();
            bool isAvailable = false;
            foreach (var book in allBooks)
            {
                if (book.getAuthor().Contains(authorData))
                {
                    Console.WriteLine(book);
                    isAvailable = true;
                }
            }
            if (isAvailable == false)
            {
                Console.WriteLine("Niestety nie ma książki napisanej przez takiego autora.");
            }
        }


    }
}
