using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class BorrowingRepository : Repository<Borrowing>
    {
        const int MAXBOOKS = 5;
        const int RETURNING_TIME = 31;
        public BorrowingRepository()
        {

        }
        public Borrowing FindBorrowingByReaderAndBook(Book book, Reader reader)
        {
            foreach (Borrowing borrowing in ElementList)
            {
                if (borrowing.GetReader().Equals(reader) && borrowing.GetBook().Equals(book))
                {
                    return borrowing;
                }
            }
            return null;
        }
        public Borrowing FindBorrowingByReaderIDAndBookID(int bookID, int readerID)
        {
            foreach (Borrowing borrowing in ElementList)
            {
                if (borrowing.GetReader().GetID() == readerID && borrowing.GetBook().GetID() == bookID)
                {
                    return borrowing;
                }
            }
            return null;
        }
        public bool SubmitBorrowing(int bookID, int readerID)
        {
            foreach (Borrowing borrowing in ElementList)
            {
                if (borrowing.GetReader().GetID() == readerID && borrowing.GetBook().GetID() == bookID)
                {
                    borrowing.SetBorrowingDateToCurrentDate();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveBorrowingFromBorrowingList(Book book, Reader reader)
        {
            List<Borrowing> temporaryList = new List<Borrowing>();
            bool isItEqual = false;
            foreach (Borrowing borrowing in ElementList)
            {
                if (borrowing.GetBook().Equals(book) && borrowing.GetReader().Equals(reader))
                {
                    temporaryList.Add(borrowing);
                    isItEqual = true;
                }
            }
            foreach (Borrowing tempBorrowing in temporaryList)
            {
                ElementList.Remove(tempBorrowing);
            }
            return isItEqual;
        }
        public int CountReaderBorrowings(int readerID)
        {
            int counter = 0;
            foreach (Borrowing borrowing in ElementList)
            {
                if (borrowing.GetReader().GetID() == readerID)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void BorrowBook(Book book, Reader reader)
        {
                DateTime borrowingDate = DateTime.Now;
                DateTime plannedReturningDate = borrowingDate.AddDays(RETURNING_TIME);
                Borrowing borrow = new Borrowing(borrowingDate, plannedReturningDate, book, reader);
                Add(borrow);
                book.Booked();
        }
        public bool IsLimitExceeded(Reader reader)
        {
            return CountReaderBorrowings(reader.GetID()) > MAXBOOKS;
        }
    }
}
