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