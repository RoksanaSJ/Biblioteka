using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.ConsoleMessage;
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
        protected ConsoleLog Log;
        public Library ()
        {
            BookRepository = new BookRepository ();
            ReaderRepository = new ReaderRepository();
            LibrarianRepository = new LibrarianRepository ();
            BorrowingRepository = new BorrowingRepository();
            ReturningRepository = new ReturningRepository ();
            ChargeInformationRepository = new ChargeInformationRepository ();
            UserRepository = new UserRepository ();
            this.Log = new ConsoleLog();
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
        public User CheckingUserExistance(string email, string password)
        {
            List<User> tempUsersList = UserRepository.Get();
            foreach (User user in tempUsersList)
            {
                if (user.GetEmail().Equals(email) && user.GetPassword().Equals(password))
                {
                    return user;
                }
            }
            return null;
        }
        //Próbowałam porobić metody do LoginMenu

        //public bool CheckingIfChangingPasswordIsNecessary(User user)
        //{
        //    return (user.GetInfoAboutPassword() == true);
        //}
        //public void ChooseRoleDependMenu(User user)
        //{
        //    bool isAdmin = false;
        //    bool isLibrarian = false;
        //    bool isReader = false;
        //    if (user.GetUserRole() == UserRole.Administrator)
        //    {
        //        isAdmin = true;
        //    }
        //    else if (user.GetUserRole() == UserRole.Librarian)
        //    {
        //        isLibrarian = true;
        //        if (user.GetInfoAboutPassword() == true)
        //        {
        //            Log.PrintInformationMessage("Musisz zmienic hasło");
        //            Console.WriteLine("Podaj nowe hasło:");
        //            string newPassword = Console.ReadLine();
        //            Console.WriteLine("Powtórz nowe hasło:");
        //            string repeatedNewPassword = Console.ReadLine();
        //            if (repeatedNewPassword == newPassword)
        //            {
        //                user.SetPassword(repeatedNewPassword);
        //                user.SetIfPasswordIsNotNeededToBeChanged();
        //                Log.PrintSuccessMessage("Garatulację, właśnie zmieniłeś hasło!");
        //            }
        //            else
        //            {
        //                Log.PrintErrorMessage("Hasła muszą być takie same!");
        //            }
        //        }
        //    }
        //    else if (user.GetUserRole() == UserRole.Reader)
        //    {
        //        isReader = true;
        //    }
        //}
        //public void ChangingLibrarianPassword()
        //{
        //    Console.WriteLine("Podaj nowe hasło:");
        //    string newPassword = Console.ReadLine();
        //    Console.WriteLine("Powtórz nowe hasło:");
        //    string repeatedNewPassword = Console.ReadLine();
        //    if (repeatedNewPassword == newPassword)
        //    {
        //        user.SetPassword(repeatedNewPassword);
        //        user.SetIfPasswordIsNotNeededToBeChanged();
        //    }
        //}
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
        public void ReturnBook(int bookID, int readerID)
        {
            Book bookFound = GetBookRepository().FindBookByID(bookID);
            Reader readerFound = GetReaderRepository().FindReaderByID(readerID);
            Borrowing borrowingFound = GetBorrowingRepository().FindBorrowingByReaderIDAndBookID(bookID, readerID);
            if (bookFound != null && readerFound != null && borrowingFound != null)
            {
                decimal charge = CountCharge(borrowingFound);
                if (charge > 0)
                {
                    ChargeInformation chargeInfo = new ChargeInformation(charge, readerFound);
                    GetChargeInformationRepository().Add(chargeInfo);
                }
                GetReturningRepository().ReturnBook(bookFound, readerFound);
                bool isItEqual = GetBorrowingRepository().RemoveBorrowingFromBorrowingList(bookFound, readerFound);
                if (isItEqual == false)
                {
                    Log.PrintErrorMessage("Nie ma takiego wypożyczenia");
                }
                Log.PrintSuccessMessage($"Gratulację, właśnie oddałeś książkę");
            }
            else
            {
                Log.PrintErrorMessage("Dane niepoprawne");
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
                Log.PrintErrorMessage($"Niestety porzetrzymałeś wypożyczoną książkę o {overkeepingDays} dni -  za każdy dzień zostanie naliczona opłata 10gr. \n Musisz zapłacić {charge} zł");
            }
            else
            {
                charge = 0;
            }
            return charge;
        }
        public void BorrowABookByBookAndReaderID(int bookID, int readerID)
        {
            List<int> notFound = new List<int>();
            List<Reader> readers = ReaderRepository.Get();
            foreach (var book in BookRepository.Get())
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
            if (notFound.Count == BookRepository.Get().Count)
            {
                Log.PrintErrorMessage("Niestety książka o takim ID nie istnieje");
            }
        }
    }
}