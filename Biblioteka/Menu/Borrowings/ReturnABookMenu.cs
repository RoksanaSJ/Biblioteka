using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Borrowings
{
    internal class ReturnABookMenu : Menu
    {
        public ReturnABookMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu() 
        {
            while (true)
            {
                Console.WriteLine("Podaj swój identyfikator:");
                int readerID = ReadOption();
                Console.WriteLine("Podaj ID książki");
                int bookID = ReadOption();
                Console.WriteLine($"Czy parametry, które chcesz podać są następujące: twoje ID {readerID}, ID książki {bookID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Library.ReturnBook(bookID, readerID);
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
