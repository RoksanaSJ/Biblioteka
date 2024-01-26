using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.ConsoleMessage;
using Biblioteka.Exception;
using Biblioteka.Menu.Books;
using Biblioteka.Model;
using Biblioteka.Repository;

namespace Biblioteka
{
    internal class Library
    {
        const int MAXBOOKS = 5;
        protected BookRepository BookRepository { get; set; }
        protected ReaderRepository ReaderRepository { get; set; }
        protected LibrarianRepository LibrarianRepository { get; set; }
        protected BorrowingRepository BorrowingRepository { get; set; }
        protected ReturningRepository ReturningRepository { get; set; }
        protected ChargeInformationRepository ChargeInformationRepository { get; set; }
        protected UserRepository UserRepository { get; set; }
        public Library ()
        {
            BookRepository = new BookRepository ();
            ReaderRepository = new ReaderRepository();
            LibrarianRepository = new LibrarianRepository ();
            BorrowingRepository = new BorrowingRepository();
            ReturningRepository = new ReturningRepository ();
            ChargeInformationRepository = new ChargeInformationRepository ();
            UserRepository = new UserRepository ();
        }
        public void ClearAllData()
        {
            BookRepository.Get().Clear();
            ReaderRepository.Get().Clear();
            LibrarianRepository.Get().Clear();
            BorrowingRepository.Get().Clear();
            ReturningRepository.Get().Clear();
            ChargeInformationRepository.Get().Clear();
            UserRepository.Get().Clear();
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
        public ChargeInformationRepository GetChargeInformationRepository()
        {
            return ChargeInformationRepository;
        }
        public UserRepository GetUserRepository() 
        {
            return UserRepository; 
        }
        public User Login(string email, string password)
        {
            List<User> tempUsersList = UserRepository.Get();
            foreach (User user in tempUsersList)
            {
                if (user.GetEmail().Equals(email) && user.GetPassword().Equals(password))
                {
                    UserRepository.SetCurrentUser(user);
                    return user;
                }
            }
            return null;
        }
        public void CreateReaderAndUser(string name, string surname, DateTime dateOfBirth, string email, string password)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            else
            {
                age = today.Year - dateOfBirth.Year;
            }
            User newUser = new User(email, password, UserRole.Reader);
            Reader reader = new Reader(name, surname, age, newUser);
            UserRepository.Add(newUser);
            ReaderRepository.Add(reader);
        }
        public void CreateLibrarianAndUser(string name, string surname, int age, string email, string temporaryPassword)
        {
            User user = new User(email, temporaryPassword, UserRole.Librarian);
            user.SetIfPasswordIsNeededToBeChanged();
            Librarian librarian = new Librarian(name, surname, age, user);
            UserRepository.Add(user);
            LibrarianRepository.Add(librarian);
        }
        public ChargeInformation ReturnBook(int bookID, int readerID)
        {
            Book bookFound = GetBookRepository().FindBookByID(bookID);
            Reader readerFound = GetReaderRepository().FindReaderByID(readerID);
            Borrowing borrowingFound = GetBorrowingRepository().FindBorrowingByReaderIDAndBookID(bookID, readerID);
            if (bookFound != null && readerFound != null && borrowingFound != null)
            {
                decimal charge = CountCharge(borrowingFound);
                ChargeInformation chargeInfo = new ChargeInformation(charge, readerFound);
                if (charge > 0)
                {
                    GetChargeInformationRepository().Add(chargeInfo);
                }
                GetReturningRepository().ReturnBook(bookFound, readerFound);
                GetBorrowingRepository().RemoveBorrowingFromBorrowingList(bookFound, readerFound);
                return chargeInfo;
            }
            else
            {
                return null;
            }
        }
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
            }
            else
            {
                charge = 0;
            }
            return charge;
        }
        public void BorrowABookByBookAndReaderID(int bookID, int readerID)
        {
            Book bookFound = BookRepository.FindBookByID(bookID);
            Reader readerFound = ReaderRepository.FindReaderByID(readerID);
            if (bookFound != null && readerFound != null)
            {
                if (bookFound.GetState() == Book.BookState.Available)
                {
                    if (BorrowingRepository.IsLimitExceeded(readerFound) == false)
                    {
                        BorrowingRepository.BorrowBook(bookFound, readerFound);
                    }
                    else
                    {
                        throw new FailureOperationException($"Nie możesz wypożyczyć więcej niż {MAXBOOKS} książek");
                    }
                }
                else
                {
                    throw new FailureOperationException("Niestety ta książka jest niedostępna do wypożyczenia");
                }
            }
            else
            {
                throw new FailureOperationException("Niestety podane dane są niepoprawne");
            }
        }
    }
}