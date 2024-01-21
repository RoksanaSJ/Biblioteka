using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class BorrowingRepository
    {
        const int MAXBOOKS = 5;
        const int RETURNING_TIME = 31;
        protected List<Borrowing> BorrowingList { get; }
        public BorrowingRepository()
        {
            BorrowingList = new List<Borrowing>();
        }
        public List<Borrowing> GetBorrowing()
        {
            return BorrowingList;
        }
        public Borrowing FindBorrowingByReaderAndBook(Book book, Reader reader)
        {
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetReader().Equals(reader) && borrowing.GetBook().Equals(book))
                {
                    return borrowing;
                }
            }
            return null;
        }
        public void ListTheBorrowings()
        {
            foreach (var item in BorrowingList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            BorrowingList.Add(borrowing);
        }
        public bool SubmitBorrowing(int bookID, int readerID)
        {
            foreach (Borrowing borrowing in BorrowingList)
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
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetBook().Equals(book) && borrowing.GetReader().Equals(reader))
                {
                    temporaryList.Add(borrowing);
                    isItEqual = true;
                }
            }
            foreach (Borrowing tempBorrowing in temporaryList)
            {
                BorrowingList.Remove(tempBorrowing);
            }
            return isItEqual;
        }
        public int CountReaderBorrowings(int readerID)
        {
            int counter = 0;
            foreach (Borrowing borrowing in BorrowingList)
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
                AddBorrowing(borrow);
                book.Booked();
        }
        public bool IsLimitExceeded(Reader reader)
        {
            return CountReaderBorrowings(reader.GetID()) > MAXBOOKS;
        }
    }
}
