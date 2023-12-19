using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Returning : Record
    {
        DateTime ReturningDate { get; set; }
        Book Book { get; set; }
        Reader Reader { get; set; }
        public Returning(DateTime returningDate, Book book, Reader reader) : base()
        {
            this.ReturningDate = returningDate;
            this.Book = book;
            this.Reader = reader;
        }
        public DateTime GetReturningDate()
        {
            return ReturningDate;
        }
        public Book GetBook()
        {
            return Book;
        }
        public Reader GetReader()
        {
            return Reader;
        }
        public void SetReturningDateToCurrentDate()
        {
            ReturningDate = DateTime.Now;
        }
        public void SetReturnedBook(Book returnedBook)
        {
            Book = returnedBook;
        }
        public void SetReader(Reader borrower)
        {
            Reader = borrower;
        }
        public override string ToString()
        {
            return "Oddanie: data oddania: " + ReturningDate + ", dane czytelnika: " + Reader + ", książka: " + Book;
        }
        public override string ToCSV()
        {
            return ReturningDate + "," + Reader.GetID() + "," + Book.GetID();
        }
    }
}
