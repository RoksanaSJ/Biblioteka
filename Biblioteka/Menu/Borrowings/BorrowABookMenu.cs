using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Biblioteka.Model;

namespace Biblioteka.Menu.Borrowings
{
    internal class BorrowABookMenu : Menu
    {
        public BorrowABookMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj swój identyfikator:");
                int userID = ReadOption();
                Console.WriteLine("Podaj ID książki");
                int ID = ReadOption();
                Console.WriteLine($"\nCzy parametry, które chcesz podać są następujące: twoje ID {userID}, ID książki {ID}?");
                Console.WriteLine("\nJeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    //tak samo, metoda w klasie library
                    List<Book> allBooks = Library.GetAllBooks();
                    List<Reader> readers = Library.GetReaders();
                    List<int> notFound = new List<int>();
                    foreach (var book in allBooks)
                    {
                        if (book.GetID() == ID)
                        {
                            foreach (var reader in readers)
                            {
                                if (reader.GetID() == userID)
                                {
                                    Library.BorrowBook(book, reader);
                                    Log.PrintSuccessMessage($"Gratulację {reader}, właśnie wypożyczyłeś książkę {book}");
                                } 
                            }
                        }
                        else
                        {
                            notFound.Add(ID);
                        }
                    }
                    if (notFound.Count == allBooks.Count)
                    {
                        Log.PrintErrorMessage("Niestety książka o takim ID nie istnieje");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    continue;
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
