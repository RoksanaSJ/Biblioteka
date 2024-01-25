using Biblioteka.Model;
using Biblioteka.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Biblioteka.Menu.Readers
{
    internal class ReaderInformation : Menu
    {
        public ReaderInformation(Library library): base(library)
        { 

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID wyszukiwanego czytelnika: ");
                int readerID = ReadOption();
                Console.WriteLine($"Czy ID po którym chcesz wyszukać to: {readerID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    Log.PrintInformationMessage("\nDane użytkownika: ");
                    Reader reader = Library.GetReaderRepository().FindReaderByID(readerID);
                    Console.WriteLine(reader);
                    Log.PrintInformationMessage("\nWypożyczenia użytkowanika: ");
                    Borrowing borrowings = Library.GetBorrowingRepository().FindBorrowingsByReaderID(readerID);
                    Console.WriteLine(borrowings);
                    Log.PrintInformationMessage("\nHistoria wypożyczeń użytkowanika: ");
                    Returning returnings = Library.GetReturningRepository().FindReturningsByReaderID(readerID);
                    Console.WriteLine(returnings);
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
        public void PrintMenuForCurrentUser()
        {
            while (true)
            {
                User currentUser = Library.GetUserRepository().GetCurrentUser();
                Log.PrintInformationMessage("Dane użytkownika: ");
                Reader reader = Library.GetReaderRepository().FindReaderByCurrentUser(currentUser);
                Console.WriteLine(reader);
                Console.WriteLine("");
                User user = Library.GetUserRepository().FindUserByCurrentUser(currentUser);
                Console.WriteLine(user);
                Log.PrintInformationMessage("\nWypożyczenia użytkowanika: ");
                Borrowing userBorrowings = Library.GetBorrowingRepository().FindBorrowingsByCurrentUser(currentUser);
                Console.WriteLine(userBorrowings);
                Log.PrintInformationMessage("\nHistoria wypożyczeń użytkowanika: ");
                Returning userReturnings = Library.GetReturningRepository().FindReturningsByCurrentUser(currentUser);
                Console.WriteLine(userReturnings);
                break;
            }
        }
    }
}
