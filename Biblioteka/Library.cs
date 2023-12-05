using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Library
    {
        List<Book> books;
        List<Reader> readers;
        List<Employee> employees;
        List<Borrowing> borrowing;
        List<Returning> returning;

       public Library ()
        {
            books = new List<Book> ();
            readers = new List<Reader> ();
            employees = new List<Employee> ();
            borrowing = new List<Borrowing> ();
            returning = new List<Returning> ();
        }
        public List<Reader> getReaders()
        {
            return readers;
        }
        public List<Book> getAllBooks()
        {
            return books;
        }
        public void listTheReaders()
        {
            foreach (var item in readers)
            {
                Console.WriteLine(item);
            }
        }
        public void listTheBooks()
        {
            foreach(var item in books)
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

        public void addEmployee(Employee p)
        {
            employees.Add(p);
        }

        public void borrowBook(Book k, Reader c)
        {
            //Czytelnik może wypożyczyć max 5 książek
            List<Book> readerBooks = new List<Book>();

            if (k.getState() == Book.BookState.Available)
            {
                if (readerBooks.Count < 6)
                {
                    DateOnly date = new DateOnly();
                    date = DateOnly.FromDateTime(DateTime.Now);
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
        public void listTheBorrowings()
        {
            foreach (var item in borrowing)
            {
                Console.WriteLine(item);
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
        public void listTheReturnings()
        {
            foreach (var item in returning)
            {
                Console.WriteLine(item);
            }
        }

        //public void overkeepingTheBook(Borrowing b,Reader reader, Book bookID)
        //{
        //    //chcę oddać książkę -> jeżeli ID oddawanej ksiażki == ID książki, która została wypożyczona, to
        //    //-> sprawdź kiedy została wypożyczona -> porównaj czy data oddania - data wypożyczenia nie jest większa niż miesiąc
        //    //-> jeśli tak, wyświetl komunikat o naliczeniu opłaty za każdy przekroczony dzień (0,2zł)
        //    foreach(var x in borrowing)
        //    {
               
        //    }
        //    DateTime returningDate = new DateTime();
        //    returningDate = DateTime.Now;
            

        //    foreach (var item in readers)
        //    {
        //        foreach(var i in books)
        //        {
        //           // if()
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
