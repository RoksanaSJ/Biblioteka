using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Biblioteka.Model;

namespace Biblioteka.Menu.Borrowing
{
    internal class BorrowABookMenu : Menu
    {
        public BorrowABookMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj swój identyfikator:");
                int userID = readOption();
                Console.WriteLine("Podaj ID książki");
                int ID = readOption();
                Console.WriteLine($"Czy parametry, które chcesz podać są następujące: twoje ID {userID}, ID książki {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = library.getAllBooks();
                    List<Reader> readers = library.getReaders();
                    List<int> notFound = new List<int>();
                    foreach (var book in allBooks)
                    {
                        if (book.getID() == ID)
                        {
                            foreach (var reader in readers)
                            {
                                if (reader.getID() == userID)
                                {
                                    library.borrowBook(book, reader);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Gratulację {reader}, właśnie wypożyczyłeś książkę {book}");
                                    Console.ResetColor();
                                    Console.WriteLine("");
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Niestety książka o takim ID nie istnieje");
                            Console.WriteLine("");
                            Console.ResetColor();
                        }
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaj poprawną opcję!");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
        }
    }
}
