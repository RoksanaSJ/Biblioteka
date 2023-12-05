using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class SearchByTitleMenu
    {
        Library library;
        public SearchByTitleMenu(Library library)
        {
            this.library = library;
        }

        public void searchByTitleMenu()
        {
            Console.WriteLine("Podaj tytuł:");
            string searchingTitle = Console.ReadLine();
            List<Book> allBooks = library.getAllBooks();
            bool isAvailable = false;

            foreach (var book in allBooks)
            {
                if (book.getTitle().Contains(searchingTitle))
                {
                    Console.WriteLine(book);
                    isAvailable = true;
                }
            }
            if (isAvailable == false)
            {
                Console.WriteLine("Niestety nie ma książki o takim tytule na stanie");
            }
        }
    }
}
