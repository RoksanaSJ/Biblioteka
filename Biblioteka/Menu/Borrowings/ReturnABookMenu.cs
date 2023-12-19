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
                int userID = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj ID książki");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine($"Czy parametry, które chcesz podać są następujące: twoje ID {userID}, ID książki {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = Library.GetAllBooks();
                    List<Reader> readers = Library.GetReaders();
                    List<Borrowing> borrowings = Library.GetBorrowings();

                    foreach (var book in allBooks)
                    {
                        if (book.GetID() == ID)
                        {
                            foreach (var reader in readers)
                            {
                                if (reader.GetID() == userID)
                                {
                                    foreach (var borrowing in borrowings)
                                    {
                                        if (borrowing.GetReader().GetID() == userID && borrowing.GetBook().GetID() == ID)
                                        {
                                                decimal charge = countCharge(borrowing); 
                                                Library.ReturnBook(book, reader);
                                            PrintSuccessMessage($"Gratulację {reader}, właśnie oddałeś książkę {book}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (userOption.Equals("n"))
                {
                    PrintMenu();
                    Console.WriteLine("");
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
        private decimal countCharge(Borrowing borrowing)
        {
            DateTime borrowingDate = new DateTime();
            borrowingDate = (DateTime)borrowing.GetDate();
            DateTime returningDate = new DateTime();
            returningDate = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan();
            var span = returningDate.Subtract(borrowingDate);
            int days = span.Days;
            decimal charge = 0;
            if (days > 31)
            {
                decimal overkeepingDays;
                overkeepingDays = ((decimal)days - 31m);
                charge = overkeepingDays * 0.1m;
                PrintErrorMessage($"Niestety porzetrzymałeś wypożyczoną książkę o {overkeepingDays} dni -  za każdy dzień zostanie naliczona opłata 10gr. \n Musisz zapłacić {charge} zł");
            }
            else
            {
                charge = 0;
            }
            return charge;
        }
    }
}
