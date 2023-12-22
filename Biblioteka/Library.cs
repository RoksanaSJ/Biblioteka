using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka
{
    internal class Library
    {
        protected List<Book> BooksList { get; }
        protected List<Reader> ReadersList { get; }
        protected List<Librarian> EmployeesList { get; }
        protected List<Borrowing> BorrowingList { get; }
        protected List<Returning> ReturningList { get; }
        const int MAXBOOKS = 5;
        public Library ()
        {
            BooksList = new List<Book> ();
            ReadersList = new List<Reader> ();
            EmployeesList = new List<Librarian> ();
            BorrowingList = new List<Borrowing> ();
            ReturningList = new List<Returning> ();
        }
        public void ClearAllData()
        {
            BooksList.Clear();
            ReadersList.Clear();
            EmployeesList.Clear();
            BorrowingList.Clear();
            ReturningList.Clear();
        }
        public List<Book> GetAllBooks()
        {
            return BooksList;
        }
        public List<Reader> GetReaders()
        {
            return ReadersList;
        }
        public List<Librarian> GetLiblarians()
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
        public void ListTheBooks()
        {
            foreach (var item in BooksList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReaders()
        {
            foreach (var item in ReadersList)
            {
                Console.WriteLine(item);
            }
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
        public void AddBook(Book k)
        {
            BooksList.Add(k);
        }
        public void AddReader(Reader c)
        {
            ReadersList.Add(c);
        }
        public void AddEmployee(Librarian p)
        {
            EmployeesList.Add(p);
        }
        public void RemoveReader(Reader c)
        {
            ReadersList.Remove(c);
        }
        public void BorrowBook(Book k, Reader c)
        {
            //Czytelnik może wypożyczyć max 5 książek
            List<Book> readerBooks = new List<Book>();

            if (k.GetState() == Book.BookState.Available)
            {
                if (countingReaderBorrowings(c.GetID()) < MAXBOOKS)
                {
                    DateTime date = new DateTime();
                    date = DateTime.Now;
                    Borrowing borrow = new Borrowing(date, k, c);
                    BorrowingList.Add(borrow);
                    // książka zarezerwowana
                    k.Booked();
                    Console.WriteLine("Zmieniono status książki na BOOKED");
                    readerBooks.Add(k);
                    Console.WriteLine("Gratulację, właśnie wypożyczyłeś książkę!");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"Nie możesz wypożyczyć więcej niż {MAXBOOKS} książek");
                    Console.WriteLine("");
                }
            } else if(k.GetState() == Book.BookState.Booked)
            {
                Console.WriteLine("Niestety ta książka jest niedostępna do wypożyczenia");
                Console.WriteLine("");
            }
            //if (readerBooks.Count > MAXBOOKS)
            //{
            //    Console.WriteLine($"Nie możesz wypożyczyć więcej niż {MAXBOOKS}");
            //}
        }
        public void ReturnBook(Book b, Reader r)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, b, r);
            ReturningList.Add(ret);
            //Książka dostępna
            b.Available();
        }

        public Book FindBookByID(int ID)
        {
            foreach(Book book in BooksList)
            {
                if(book.GetID() == ID)
                {
                    return book;
                }
            }
            return null;
        }
        public Reader FindReaderByID(int ID)
        {
            foreach (Reader reader in ReadersList)
            {
                if (reader.GetID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public Borrowing SubmitBorrowing(int bookID, int readerID)
        {
            foreach(Borrowing borrowing in BorrowingList)
            {
                if(borrowing.GetReader().GetID() == readerID && borrowing.GetBook().GetID() == bookID)
                {
                    borrowing.SetBorrowingDateToCurrentDate();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gratulację, właśnie przedłużyłeś wypożyczenie książki o kolejny miesiąc!");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dane, które podałeś są niepoprawne");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
            return null;
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            BorrowingList.Add(borrowing);
        }
        public int countingReaderBorrowings(int readerID)
        {
            int counter = 0;
           foreach(Borrowing borrowing in BorrowingList)
            {
                if(borrowing.GetReader().GetID() == readerID)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
