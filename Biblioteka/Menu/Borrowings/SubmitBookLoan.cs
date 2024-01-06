using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Borrowings
{
    internal class SubmitBookLoan : Menu
    {
        public SubmitBookLoan(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while(true)
            {
                Console.WriteLine("Podaj swoje ID");
                int readerID = ReadOption();
                Console.WriteLine("Podaj ID książki");
                int bookID = ReadOption();
                Console.WriteLine($"Czy dane, które podałeś się zgadzają: ID czytelnika {readerID}, ID książki {bookID}");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Library.SubmitBorrowing(bookID, readerID);
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
