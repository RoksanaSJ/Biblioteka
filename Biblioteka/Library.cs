using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.ConsoleMessage;
using Biblioteka.Model;
using Biblioteka.Repository;

namespace Biblioteka
{
    //klasę library dzielimy na mniejsze klasy?
    internal class Library
    {
        const int MAXBOOKS = 5;
        protected User CurrentUser { get; set; }
        protected BookRepository BookRepository { get; set; }
        protected ReaderRepository ReaderRepository { get; set; }
        protected LibrarianRepository LibrarianRepository { get; set; }
        protected BorrowingRepository BorrowingRepository { get; set; }
        protected ReturningRepository ReturningRepository { get; set; }
        protected List<ChargeInformation> ChargeInformationList { get; }
        protected List<User> UsersList { get; }
        protected ConsoleLog Log;
        public Library ()
        {
            BookRepository = new BookRepository ();
            ReaderRepository = new ReaderRepository();
            LibrarianRepository = new LibrarianRepository ();
            BorrowingRepository = new BorrowingRepository();
            ReturningRepository = new ReturningRepository ();
            ChargeInformationList = new List<ChargeInformation>();
            UsersList = new List<User> ();
            this.Log = new ConsoleLog();
        }
        public void ClearAllData()
        {
            BookRepository.GetBooks().Clear();
            ReaderRepository.GetReaders().Clear();
            LibrarianRepository.GetLibrarians().Clear();
            BorrowingRepository.GetBorrowing().Clear();
            ReturningRepository.GetReturnings().Clear();
            ChargeInformationList.Clear();
            UsersList.Clear();
        }
        public BookRepository GetBookRepository()
        {
            return BookRepository;
        }
        public ReaderRepository GetReaderRepository()
        {
            return ReaderRepository;
        }
        public LibrarianRepository GetLibrarianRepository()
        {
            return LibrarianRepository;
        }
        public BorrowingRepository GetBorrowingRepository()
        {
            return BorrowingRepository;
        }
        public ReturningRepository GetReturningRepository()
        {
            return ReturningRepository;
        }
        public List<ChargeInformation> GetChargeInformation()
        {
            return ChargeInformationList;
        }
        public List<User> GetUsers()
        {
            return UsersList;
        }
        public User GetCurrentUser()
        {
            return CurrentUser;
        }
        public List<string> GetUsersEmails()
        {
            List<string> usersEmails = new List<string>();
            foreach(User user in UsersList)
            {
                usersEmails.Add(user.GetEmail());
            }
            return usersEmails;
        }
        public void SetCurrentUser(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
        public void ListChargeIformation()
        {
            foreach (ChargeInformation chargeInformation in ChargeInformationList)
            {
                Console.WriteLine(chargeInformation);
            }
        }
        public void ListUsers()
        {
            foreach (User users in UsersList)
            {
                Console.WriteLine(users);
            }
        }
        public void AddChargeInformation(ChargeInformation chargeInformation)
        {
            ChargeInformationList.Add(chargeInformation);
        }
        public void AddUser(User user)
        {
            UsersList.Add(user);
        }
        public void BorrowABookByBookAndReaderID(int bookID, int readerID)
        {
            List<int> notFound = new List<int>();
            List<Reader> readers = ReaderRepository.GetReaders();
            foreach (var book in BookRepository.GetBooks())
            {
                if (book.GetID() == bookID)
                {
                    foreach (var reader in readers)
                    {
                        if (reader.GetID() == readerID)
                        {
                            if (book.GetState() == Book.BookState.Available)
                            {
                                if (BorrowingRepository.IsLimitExceeded(reader) == false)
                                {
                                    BorrowingRepository.BorrowBook(book, reader);
                                    Log.PrintSuccessMessage($"Gratulację {reader}, właśnie wypożyczyłeś książkę {book}");
                                }
                                else
                                {
                                    Log.PrintErrorMessage($"Nie możesz wypożyczyć więcej niż {MAXBOOKS} książek");
                                }
                            }
                            else
                            {
                                Log.PrintErrorMessage("Niestety ta książka jest niedostępna do wypożyczenia");
                            }
                        }
                    }
                }
                else
                {
                    notFound.Add(bookID);
                }
            }
            if (notFound.Count == BookRepository.GetBooks().Count)
            {
                Log.PrintErrorMessage("Niestety książka o takim ID nie istnieje");
            }
        }
        //public void ReturnBook(Book b, Reader r)
        //{
        //    DateTime date = new DateTime();
        //    date = DateTime.Now;
        //    Returning ret = new Returning(date, b, r);
        //    ReturningList.Add(ret);
        //    bool isItEqual = BorrowingRepository.RemoveBorrowingFromBorrowingList(b, r);
        //    if (isItEqual == false)
        //    {
        //        Log.PrintErrorMessage("Nie ma takiego wypożyczenia");
        //    }
        //    else
        //    {
        //        b.Available();
        //        Log.PrintInformationMessage("Zmieniono status książki na AVAILABLE");
        //    }
        //}
        public void ChargeInformationForSpecificReader(int readerID)
        {
            bool found = false;
            foreach (ChargeInformation chargeInformation in ChargeInformationList)
            {
                if (chargeInformation.GetReader().GetID() == readerID)
                {
                    Console.WriteLine(chargeInformation);
                    found = true;
                }
                else
                {
                    found = false;
                    Log.PrintErrorMessage("Dany czytelnik nie został obciążony żadną opłatą");
                }
            }
        }
        public void PrintHistoryFromPeriod(DateTime startDate, DateTime finishDate)
        {
            if (finishDate >= startDate)
            {
                foreach (ChargeInformation chargeInformation in ChargeInformationList)
                {
                    if (chargeInformation.GetDateOfCharge() >= startDate && chargeInformation.GetDateOfCharge() <= finishDate)
                    {
                        Log.PrintInformationMessage(chargeInformation.ToString());
                        Console.WriteLine("");
                    }
                }
            } 
            else
            {
                Log.PrintErrorMessage("Data końcowa powinna być późniejsza niż początkowa");
            }
        }
    }
}