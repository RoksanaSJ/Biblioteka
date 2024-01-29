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
                Console.WriteLine($"\nCzy dane, które podałeś się zgadzają: ID czytelnika {readerID}, ID książki {bookID}");
                Console.WriteLine("\nJeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    bool result = Library.GetBorrowingRepository().SubmitBorrowing(bookID, readerID);
                    if(result)
                    {
                        Log.PrintSuccessMessage("Gratulację, właśnie przedłużyłeś wypożyczenie książki o kolejny miesiąc!");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Dane, które podałeś są niepoprawne");
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
