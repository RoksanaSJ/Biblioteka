using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Borrowing : Record
    {
        protected DateTime BorrowingDate { get; set; }
        protected Book Book { get; set; }
        protected Reader Reader { get; set; }
        public Borrowing(DateTime date, Book book, Reader reader) : base()
        {
            BorrowingDate = date;
            this.Reader = reader;
            this.Book = book;
        }
        public DateTime GetDate()
        {
            return BorrowingDate;
        }
        public Book GetBook()
        {
            return Book;
        }
        public Reader GetReader()
        {
            return Reader;
        }
        public void SetBorrowingDateToCurrentDate()
        {
            BorrowingDate = DateTime.Now;
        }
        public void SetBorrowedBook(Book borrowedBook)
        {
            Book = borrowedBook;
        }
        public void SetReader(Reader borrower)
        {
            Reader = borrower;
        }
        public override string ToString()
        {
            return "Wypożyczenie: data wypożyczenia: " + BorrowingDate + $" \n" + Reader + ", \n" + Book +"\n";
        }
        public override string ToCSV()
        {
            return BorrowingDate + "," + Reader.GetID()+ "," + Book.GetID();
        }
    }
}
