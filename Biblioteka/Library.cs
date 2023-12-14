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
        public Library ()
        {
            books = new List<Book> ();
            readers = new List<Reader> ();
            employees = new List<Librarian> ();
            borrowing = new List<Borrowing> ();
            returning = new List<Returning> ();
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
                if (readerBooks.Count < 6)
                {
                    DateTime date = new DateTime(2023,10,14);
                   // date = DateTime.Now;
                    Borrowing borrow = new Borrowing(date, k, c);
                    borrowing.Add(borrow);
                    // książka zarezerwowana
                    k.booked();
                    //Czytelnik może wypożyczyć max 5 książek
                    readerBooks.Add(k);
                }
            }
            if (readerBooks.Count == 6)
            {
                Console.WriteLine("Nie możesz wypożyczyć więcej niż 5 ksiażek");
            }
        }
        public void returnBook(Book b, Reader r)
        {
            DateOnly date = new DateOnly();
            date = DateOnly.FromDateTime(DateTime.Now);
            Returning ret = new Returning(date, b, r);
            returning.Add(ret);
            //Książka dostępna
            b.available();
        }
    }
}
