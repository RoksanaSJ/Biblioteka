using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
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
                    ChargeInformation result = Library.ReturnBook(bookID, readerID);
                    if(result != null)
                    {
                        if (result.GetCharge() > 0)
                        {
                            Log.PrintErrorMessage($"Niestety porzetrzymałeś wypożyczoną książkę -  za każdy dzień zostanie naliczona opłata 10gr. " +
                                $"\n Musisz zapłacić {result.GetCharge()} zł");
                        }
                        Log.PrintSuccessMessage($"Gratulację, właśnie oddałeś książkę");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Nie znaleziono takiego wypożyczenia");
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
