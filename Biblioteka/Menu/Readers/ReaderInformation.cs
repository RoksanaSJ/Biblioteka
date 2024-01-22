using Biblioteka.Model;
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
                int readID = ReadOption();
                Console.WriteLine($"Czy ID po którym chcesz wyszukać to: {readID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    //osobna metoda w klasie library, a nawet więcej niż 1 metoda
                    List<Reader> readerInfo = new List<Reader>();
                    readerInfo = Library.GetReaderRepository().GetReaders();
                    List<Borrowing> borrowings = new List<Borrowing>();
                    borrowings = Library.GetBorrowingRepository().GetBorrowing();
                    List<Returning> readerReturnings = new List<Returning>();
                    readerReturnings = Library.GetReturningRepository().GetReturnings();
                    Log.PrintInformationMessage("Dane użytkownika: ");
                    foreach (Reader reader in readerInfo)
                    {
                        if (reader.GetID() == readID)
                        {
                            Console.WriteLine(reader);
                        }
                    }
                    Console.WriteLine("");
                    Log.PrintInformationMessage("Wypożyczenia użytkowanika: ");
                    foreach (Borrowing borrowing in borrowings)
                    {
                        if (borrowing.GetReader().GetID() == readID)
                        {
                            Console.WriteLine(borrowing);
                        }
                    }
                    Console.WriteLine("");
                    Log.PrintInformationMessage("Historia wypożyczeń użytkowanika: ");
                    foreach (Returning returning in readerReturnings)
                    {
                        if (returning.GetReader().GetID() == readID)
                        {
                            Console.WriteLine(returning);
                        }
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
        public void PrintMenuForCurrentUser()
        {
            while (true)
            {
                List<Reader> readers = Library.GetReaderRepository().GetReaders();
                User currentUser = Library.GetUserRepository().GetCurrentUser();
                List<User> userInfo = Library.GetUserRepository().GetUsers();
                List<Borrowing> borrowings = new List<Borrowing>();
                borrowings = Library.GetBorrowingRepository().GetBorrowing();
                List<Returning> readerReturnings = new List<Returning>();
                readerReturnings = Library.GetReturningRepository().GetReturnings();
                Log.PrintInformationMessage("Dane użytkownika: ");
                foreach(Reader reader in readers)
                {
                    if (reader.GetUser().Equals(currentUser))
                    {
                        Console.WriteLine(reader);
                    }
                }
                Console.WriteLine("");
                foreach (User user in userInfo)
                {
                    if (user.Equals(currentUser))
                    {
                        Console.WriteLine(user);
                    }
                }
                Console.WriteLine("");
                Log.PrintInformationMessage("Wypożyczenia użytkowanika: ");
                foreach (Borrowing borrowing in borrowings)
                {
                    if (borrowing.GetReader().GetUser().Equals(currentUser))
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                Console.WriteLine("");
                Log.PrintInformationMessage("Historia wypożyczeń użytkowanika: ");
                foreach (Returning returning in readerReturnings)
                {
                    if (returning.GetReader().GetUser().Equals(currentUser))
                    {
                        Console.WriteLine(returning);
                    }
                }
                break;
            }
        }
    }
}
