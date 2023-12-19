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
        protected List<Book> books { get; }
        protected List<Reader> readers { get; }
        protected List<Librarian> employees { get; }
        protected List<Borrowing> borrowing { get; }
        protected List<Returning> returning { get; }
        const int MAXBOOKS = 5;
        public Library ()
        {
            books = new List<Book> ();
            readers = new List<Reader> ();
            employees = new List<Librarian> ();
            borrowing = new List<Borrowing> ();
            returning = new List<Returning> ();
        }
        public void clearAllData()
        {
            books.Clear();
            readers.Clear();
            employees.Clear();
            borrowing.Clear();
            returning.Clear();
        }
        public List<Book> getAllBooks()
        {
            return books;
        }
        public List<Reader> getReaders()
        {
            return readers;
        }
        public List<Librarian> getLiblarians()
        {
            return employees;
        }
        public List<Borrowing> getBorrowings()
        {
            return borrowing;
        }
        public List<Returning> getReturnings()
        {
            return returning;
        }
        public void listTheBooks()
        {
            foreach (var item in books)
            {
                Console.WriteLine(item);
            }
        }
        public void listTheReaders()
        {
            foreach (var item in readers)
            {
                Console.WriteLine(item);
            }
        }
        public void listTheLibrarians()
        {
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
        public void listTheBorrowings()
        {
            foreach (var item in borrowing)
            {
                Console.WriteLine(item);
            }
        }
        public void listTheReturnings()
        {
            foreach (var item in returning)
            {
                Console.WriteLine(item);
            }
        }
        public void addBook(Book k)
        {
            books.Add(k);
        }
        public void addReader(Reader c)
        {
            readers.Add(c);
        }
        public void addEmployee(Librarian p)
        {
            employees.Add(p);
        }
        public void removeReader(Reader c)
        {
            readers.Remove(c);
        }
        public void borrowBook(Book k, Reader c)
        {
            //Czytelnik może wypożyczyć max 5 książek
            List<Book> readerBooks = new List<Book>();

            if (k.getState() == Book.BookState.Available)
            {
                if (readerBooks.Count <= MAXBOOKS)
                {
                    DateTime date = new DateTime();
                    date = DateTime.Now;
                    Borrowing borrow = new Borrowing(date, k, c);
                    borrowing.Add(borrow);
                    // książka zarezerwowana
                    k.booked();
                    //Czytelnik może wypożyczyć max 5 książek
                    readerBooks.Add(k);
                }
            }
            if (readerBooks.Count > MAXBOOKS)
            {
                Console.WriteLine($"Nie możesz wypożyczyć więcej niż {MAXBOOKS}");
            }
        }
        public void returnBook(Book b, Reader r)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, b, r);
            returning.Add(ret);
            //Książka dostępna
            b.available();
        }

        public Book findBookByID(int ID)
        {
            foreach(Book book in books)
            {
                if(book.getID() == ID)
                {
                    return book;
                }
            }
            return null;
        }
        public Reader findReaderByID(int ID)
        {
            foreach (Reader reader in readers)
            {
                if (reader.getID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public void addBorrowing(Borrowing borrowing)
        {
            this.borrowing.Add(borrowing);
        }
    }
}
