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
                int userID = ReadOption();
                Console.WriteLine("Podaj ID książki");
                int bookID = ReadOption();
                Console.WriteLine($"Czy parametry, które chcesz podać są następujące: twoje ID {userID}, ID książki {bookID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Book bookFound = Library.FindBookByID(bookID);
                    Reader readerFound = Library.FindReaderByID(userID);
                    Borrowing borrowingFound = Library.FindBorrowingByReaderAndBook(bookFound, readerFound);
                    if (bookFound != null && readerFound != null && borrowingFound != null)
                    {
                        //-------- NIE WCHODZI TU
                        Console.WriteLine("Czy tu wchodzi");
                        decimal charge = CountCharge(borrowingFound);
                        if(charge > 0)
                        {
                            ChargeInformation chargeInfo = new ChargeInformation(charge, readerFound);
                            Library.AddChargeInformation(chargeInfo);
                            //---NIE WCHODZI TU
                            Console.WriteLine("ReturnABookMenu");
                        }
                        Library.ReturnBook(bookFound, readerFound);
                        Log.PrintSuccessMessage($"Gratulację, właśnie oddałeś książkę");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dane niepoprawne");
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
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
        private decimal CountCharge(Borrowing borrowing)
        {
            DateTime borrowingDate = new DateTime();
            borrowingDate = (DateTime)borrowing.GetDate();
            DateTime returningDate = new DateTime();
            returningDate = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan();
            var span = returningDate.Subtract(borrowingDate);
            int days = span.Days;
            decimal charge = 0;
            if (days > 2)
            {
                decimal overkeepingDays = ((decimal)days - 2m);
                charge = overkeepingDays * 0.1m;
                Log.PrintErrorMessage($"Niestety porzetrzymałeś wypożyczoną książkę o {overkeepingDays} dni -  za każdy dzień zostanie naliczona opłata 10gr. \n Musisz zapłacić {charge} zł");
            }
            else
            {
                charge = 0;
            }
            return charge;
        }
    }
}
