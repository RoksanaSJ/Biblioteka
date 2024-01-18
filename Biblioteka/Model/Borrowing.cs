using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Borrowing : Record
    {
        private DateTime BorrowingDate { get; set; }
        private DateTime PlannedReturningDate { get; set; }
        private Book Book { get; set; }
        private Reader Reader { get; set; }
        public Borrowing(DateTime date, DateTime plannedReturningDate, Book book, Reader reader) : base()
        {
            BorrowingDate = date;
            PlannedReturningDate = plannedReturningDate;
            this.Reader = reader;
            this.Book = book;
        }
        public DateTime GetBorrowingDate()
        {
            return BorrowingDate;
        }
        public DateTime GetPlannedReturningDate()
        {
            return PlannedReturningDate;
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
        public void SetPlannedReturningDate()
        {
            DateTime borrowingDate = GetBorrowingDate();
            DateTime returningDate = borrowingDate.AddDays(31);
            PlannedReturningDate = returningDate;
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
            return "Wypożyczenie: data wypożyczenia: " + BorrowingDate + " Planowana data oddania" + PlannedReturningDate +$" \n" + Reader + ", \n" + Book +"\n";
        }
        public override string ToCSV()
        {
            return BorrowingDate + "," + PlannedReturningDate + "," + Reader.GetID()+ "," + Book.GetID();
        }
    }
}
