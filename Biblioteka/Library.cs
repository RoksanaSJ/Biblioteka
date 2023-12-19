using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka
{
    internal class Library
    {
        protected List<Book> Books { get; }
        protected List<Reader> Readers { get; }
        protected List<Librarian> Employees { get; }
        protected List<Borrowing> Borrowing { get; }
        protected List<Returning> Returning { get; }
        const int MAXBOOKS = 5;
        public Library ()
        {
            Books = new List<Book> ();
            Readers = new List<Reader> ();
            Employees = new List<Librarian> ();
            Borrowing = new List<Borrowing> ();
            Returning = new List<Returning> ();
        }
        public void ClearAllData()
        {
            Books.Clear();
            Readers.Clear();
            Employees.Clear();
            Borrowing.Clear();
            Returning.Clear();
        }
        public List<Book> GetAllBooks()
        {
            return Books;
        }
        public List<Reader> GetReaders()
        {
            return Readers;
        }
        public List<Librarian> GetLiblarians()
        {
            return Employees;
        }
        public List<Borrowing> GetBorrowings()
        {
            return Borrowing;
        }
        public List<Returning> GetReturnings()
        {
            return Returning;
        }
        public void ListTheBooks()
        {
            foreach (var item in Books)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReaders()
        {
            foreach (var item in Readers)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheLibrarians()
        {
            foreach (var item in Employees)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheBorrowings()
        {
            foreach (var item in Borrowing)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReturnings()
        {
            foreach (var item in Returning)
            {
                Console.WriteLine(item);
            }
        }
        public void AddBook(Book k)
        {
            Books.Add(k);
        }
        public void AddReader(Reader c)
        {
            Readers.Add(c);
        }
        public void AddEmployee(Librarian p)
        {
            Employees.Add(p);
        }
        public void RemoveReader(Reader c)
        {
            Readers.Remove(c);
        }
        public void BorrowBook(Book k, Reader c)
        {
            //Czytelnik może wypożyczyć max 5 książek
            List<Book> readerBooks = new List<Book>();

            if (k.GetState() == Book.BookState.Available)
            {
                if (readerBooks.Count <= MAXBOOKS)
                {
                    DateTime date = new DateTime();
                    date = DateTime.Now;
                    Borrowing borrow = new Borrowing(date, k, c);
                    Borrowing.Add(borrow);
                    // książka zarezerwowana
                    k.Booked();
                    //Czytelnik może wypożyczyć max 5 książek
                    readerBooks.Add(k);
                }
            }
            if (readerBooks.Count > MAXBOOKS)
            {
                Console.WriteLine($"Nie możesz wypożyczyć więcej niż {MAXBOOKS}");
            }
        }
        public void ReturnBook(Book b, Reader r)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, b, r);
            Returning.Add(ret);
            //Książka dostępna
            b.Available();
        }

        public Book FindBookByID(int ID)
        {
            foreach(Book book in Books)
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
            foreach (Reader reader in Readers)
            {
                if (reader.GetID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            this.Borrowing.Add(borrowing);
        }
    }
}
