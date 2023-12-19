using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Returning : Record
    {
        DateTime returningDate { get; set; }
        Book book { get; set; }
        Reader reader { get; set; }
        public Returning(DateTime returningDate, Book book, Reader reader) : base()
        {
            this.returningDate = returningDate;
            this.book = book;
            this.reader = reader;
        }
        public DateTime getReturningDate()
        {
            return returningDate;
        }
        public Book getBook()
        {
            return book;
        }
        public Reader getReader()
        {
            return reader;
        }
        public void setReturningDateToCurrentDate()
        {
            returningDate = DateTime.Now;
        }
        public void setReturnedBook(Book returnedBook)
        {
            book = returnedBook;
        }
        public void setReader(Reader borrower)
        {
            reader = borrower;
        }
        public override string ToString()
        {
            return "Oddanie: data oddania: " + returningDate + ", dane czytelnika: " + reader + ", książka: " + book;
        }
        public override string toCSV()
        {
            return returningDate + "," + reader.getID() + "," + book.getID();
        }
    }
}
