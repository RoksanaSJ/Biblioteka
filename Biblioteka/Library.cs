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
        protected List<Librarian> EmployeesList { get; }
        protected List<Borrowing> BorrowingList { get; }
        protected List<Returning> ReturningList { get; }
        protected List<ChargeInformation> ChargeInformationList { get; }
        protected List<User> UsersList { get; }
        protected ConsoleLog Log;
        public Library ()
        {
            BookRepository = new BookRepository ();
            ReaderRepository = new ReaderRepository();
            EmployeesList = new List<Librarian> ();
            BorrowingList = new List<Borrowing> ();
            ReturningList = new List<Returning> ();
            ChargeInformationList = new List<ChargeInformation>();
            UsersList = new List<User> ();
            this.Log = new ConsoleLog();
        }
        public void ClearAllData()
        {
            BookRepository.GetBooks().Clear();
            ReaderRepository.GetReaders().Clear();
            EmployeesList.Clear();
            BorrowingList.Clear();
            ReturningList.Clear();
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
        public List<Librarian> GetLibrarians()
        {
            return EmployeesList;
        }
        public List<Borrowing> GetBorrowings()
        {
            return BorrowingList;
        }
        public List<Returning> GetReturnings()
        {
            return ReturningList;
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
        public void ListTheLibrarians()
        {
            foreach (var item in EmployeesList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheBorrowings()
        {
            foreach (var item in BorrowingList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReturnings()
        {
            foreach (var item in ReturningList)
            {
                Console.WriteLine(item);
            }
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
        public void AddEmployee(Librarian p)
        {
            EmployeesList.Add(p);
        }
        public void AddChargeInformation(ChargeInformation chargeInformation)
        {
            ChargeInformationList.Add(chargeInformation);
        }
        public void AddReturning(Returning returning)
        {
            ReturningList.Add(returning);
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            BorrowingList.Add(borrowing);
        }
        public void AddUser(User user)
        {
            UsersList.Add(user);
        }
        public List<Borrowing> RemoveBorrowingFromBorrowingList(Book b, Reader r)
        {
            List<Borrowing> temporaryList = new List<Borrowing>();
            bool isItEqual = false;
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetBook().Equals(b) && borrowing.GetReader().Equals(r))
                {
                    temporaryList.Add(borrowing);
                    isItEqual = true;
                }
            }
            if (isItEqual == false)
            {
                Log.PrintErrorMessage("Nie ma takiego wypożyczenia");
            }
            foreach (Borrowing tempBorrowing in temporaryList)
            {
                BorrowingList.Remove(tempBorrowing);
            }
            return BorrowingList;
        }
        public void BorrowBook(Book k, Reader c)
        {
            List<Book> readerBooks = new List<Book>();

            if (k.GetState() == Book.BookState.Available)
            {
                if (CountReaderBorrowings(c.GetID()) < MAXBOOKS)
                {
                    DateTime borrowingDate = DateTime.Now;
                    DateTime plannedReturningDate = borrowingDate.AddDays(31); 
                    Borrowing borrow = new Borrowing(borrowingDate, plannedReturningDate, k, c);
                    BorrowingList.Add(borrow);
                    k.Booked();
                    Log.PrintInformationMessage("Zmieniono status książki na BOOKED");
                    readerBooks.Add(k);
                }
                else
                {
                    Log.PrintErrorMessage($"Nie możesz wypożyczyć więcej niż {MAXBOOKS} książek");
                }
            } else if(k.GetState() == Book.BookState.Booked)
            {
                Log.PrintErrorMessage("Niestety ta książka jest niedostępna do wypożyczenia");
            }
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
                            BorrowBook(book, reader);
                            Log.PrintSuccessMessage($"Gratulację {reader}, właśnie wypożyczyłeś książkę {book}");
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
        public void ReturnBook(Book b, Reader r)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, b, r);
            ReturningList.Add(ret);
            RemoveBorrowingFromBorrowingList(b, r);
            b.Available();
            Log.PrintInformationMessage("Zmieniono status książki na AVAILABLE");
        }
        public Borrowing FindBorrowingByReaderAndBook(Book book, Reader reader) 
        { 
            foreach(Borrowing borrowing in BorrowingList)
            {
                if(borrowing.GetReader().Equals(reader) && borrowing.GetBook().Equals(book))
                {
                    return borrowing;
                }
            }
            return null;
        }
        public int CountReaderBorrowings(int readerID)
        {
            int counter = 0;
            bool isExist = false;
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetReader().GetID() == readerID)
                {
                    counter++;
                    isExist = true;
                }
            }
            if (isExist == false)
            {
                Log.PrintErrorMessage("Niestety ten użytkownik, nie dokonał takiego wypożyczenia");
            }
            return counter;
        }
        public void ChargeInformationForSpecificReader(int readerID)
        {
            bool found = false;
            foreach (ChargeInformation chargeInformation in ChargeInformationList)
            {
                if (chargeInformation.GetReader().GetID() == readerID)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(chargeInformation);
                    Console.ResetColor();
                    Console.WriteLine("");
                    found = true;
                }
                else
                {
                    found = false;
                    Log.PrintErrorMessage("Dany czytelnik nie został obciążony żadną opłatą");
                }
            }
        }
        public void SubmitBorrowing(int bookID, int readerID)
        {
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetReader().GetID() == readerID && borrowing.GetBook().GetID() == bookID)
                {
                    borrowing.SetBorrowingDateToCurrentDate();
                    Log.PrintSuccessMessage("Gratulację, właśnie przedłużyłeś wypożyczenie książki o kolejny miesiąc!");
                }
                else
                {
                    Log.PrintErrorMessage("Dane, które podałeś są niepoprawne");
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