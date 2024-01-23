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
                    //jako metoda w klasie library
                    Book bookFound = Library.GetBookRepository().FindBookByID(bookID);
                    Reader readerFound = Library.GetReaderRepository().FindReaderByID(userID);
                    Borrowing borrowingFound = Library.GetBorrowingRepository().FindBorrowingByReaderAndBook(bookFound, readerFound);
                    if (bookFound != null && readerFound != null && borrowingFound != null)
                    {
                        decimal charge = CountCharge(borrowingFound);
                        if(charge > 0)
                        {
                            ChargeInformation chargeInfo = new ChargeInformation(charge, readerFound);
                            Library.GetChargeInformationRepository().Add(chargeInfo);
                        }
                        Library.GetReturningRepository().ReturnBook(bookFound, readerFound);
                        //Wcześniej to co jest niżej było w metodzie ReturnBook
                        bool isItEqual = Library.GetBorrowingRepository().RemoveBorrowingFromBorrowingList(bookFound, readerFound);
                        if (isItEqual == false)
                        {
                            Log.PrintErrorMessage("Nie ma takiego wypożyczenia");
                        }
                        Log.PrintSuccessMessage($"Gratulację, właśnie oddałeś książkę");
                        break;
                    }
                    else
                    {
                        Log.PrintErrorMessage("Dane niepoprawne");
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
        //oosbna klasa z tą metodą
        private decimal CountCharge(Borrowing borrowing)
        {
            DateTime borrowingDate = new DateTime();
            borrowingDate = (DateTime)borrowing.GetBorrowingDate();
            DateTime returningDate = new DateTime();
            returningDate = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan();
            var span = returningDate.Subtract(borrowingDate);
            int days = span.Days;
            decimal charge = 0;
            if (days > 31)
            {
                decimal overkeepingDays = ((decimal)days - 31m);
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
