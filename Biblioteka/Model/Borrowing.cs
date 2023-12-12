using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Borrowing
    {
        protected DateOnly borrowingDate { get; set; }
        protected Book book { get; set; }
        protected Reader reader { get; set; }
        public Borrowing(DateOnly date, Book book, Reader reader)
        {
            borrowingDate = date;
            this.reader = reader;
            this.book = book;
        }
        public DateOnly getDate()
        {
            return borrowingDate;
        }
        public Book getBook()
        {
            return book;
        }
        public Reader getReader()
        {
            return reader;
        }
        public void setBorrowingDateToCurrentDate()
        {
            borrowingDate = DateOnly.FromDateTime(DateTime.Now);
        }
        public void setBorrowedBook(Book borrowedBook)
        {
            book = borrowedBook;
        }
        public void setReader(Reader borrower)
        {
            reader = borrower;
        }
        public override string ToString()
        {
            return "Wypożyczenie: data wypożyczenia: " + borrowingDate + $", \n" + reader + ", \n" + book +"\n";
        }
    }
}
