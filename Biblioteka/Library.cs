﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.ConsoleMessage;
using Biblioteka.Model;

namespace Biblioteka
{
    internal class Library
    {
        const int MAXBOOKS = 5;
        protected List<Book> BooksList { get; }
        protected List<Reader> ReadersList { get; }
        protected List<Librarian> EmployeesList { get; }
        protected List<Borrowing> BorrowingList { get; }
        protected List<Returning> ReturningList { get; }
        protected ConsoleLog Log;
        public Library ()
        {
            BooksList = new List<Book> ();
            ReadersList = new List<Reader> ();
            EmployeesList = new List<Librarian> ();
            BorrowingList = new List<Borrowing> ();
            ReturningList = new List<Returning> ();
            this.Log = new ConsoleLog();
        }
        public void ClearAllData()
        {
            BooksList.Clear();
            ReadersList.Clear();
            EmployeesList.Clear();
            BorrowingList.Clear();
            ReturningList.Clear();
        }
        public List<Book> GetAllBooks()
        {
            return BooksList;
        }
        public List<Reader> GetReaders()
        {
            return ReadersList;
        }
        public List<Librarian> GetLibrarians()
        {
            return EmployeesList;
        }
        public List<Borrowing> GetBorrowings()
        {
            return BorrowingList;
        }
        public List<Returning> GetReturnings()
        {
            return ReturningList;
        }
        public void ListTheBooks()
        {
            foreach (var item in BooksList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReaders()
        {
            foreach (var item in ReadersList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheLibrarians()
        {
            foreach (var item in EmployeesList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheBorrowings()
        {
            foreach (var item in BorrowingList)
            {
                Console.WriteLine(item);
            }
        }
        public void ListTheReturnings()
        {
            foreach (var item in ReturningList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddBook(Book k)
        {
            BooksList.Add(k);
        }
        public void AddReader(Reader c)
        {
            ReadersList.Add(c);
        }
        public void AddEmployee(Librarian p)
        {
            EmployeesList.Add(p);
        }
        public void RemoveReader(Reader c)
        {
            ReadersList.Remove(c);
        }
        public void BorrowBook(Book k, Reader c)
        {
            //Czytelnik może wypożyczyć max 5 książek
            List<Book> readerBooks = new List<Book>();

            if (k.GetState() == Book.BookState.Available)
            {
                if (countingReaderBorrowings(c.GetID()) < MAXBOOKS)
                {
                    DateTime date = new DateTime();
                    date = DateTime.Now;
                    Borrowing borrow = new Borrowing(date, k, c);
                    BorrowingList.Add(borrow);
                    // książka zarezerwowana
                    k.Booked();
                    Log.PrintInformationMessage("Zmieniono status książki na BOOKED");
                    readerBooks.Add(k);
                }
                else
                {
                    Log.PrintErrorMessage($"Nie możesz wypożyczyć więcej niż {MAXBOOKS} książek");
                }
            } else if(k.GetState() == Book.BookState.Booked)
            {
                Log.PrintErrorMessage("Niestety ta książka jest niedostępna do wypożyczenia");
            }
        }
        public void ReturnBook(Book b, Reader r)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, b, r);
            ReturningList.Add(ret);
            removeBorrowingFromBorrowingList(b, r);
            //Książka dostępna
            b.Available();
            Log.PrintInformationMessage("Zmieniono status książki na AVAILABLE");
        }
        public Book FindBookByID(int ID)
        {
            foreach(Book book in BooksList)
            {
                if(book.GetID() == ID)
                {
                    return book;
                }
            }
            return null;
        }
        public Reader FindReaderByID(int ID)
        {
            foreach (Reader reader in ReadersList)
            {
                if (reader.GetID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public void SubmitBorrowing(int bookID, int readerID)
        {
            foreach(Borrowing borrowing in BorrowingList)
            {
                if(borrowing.GetReader().GetID() == readerID && borrowing.GetBook().GetID() == bookID)
                {
                    borrowing.SetBorrowingDateToCurrentDate();
                    Log.PrintSuccessMessage("Gratulację, właśnie przedłużyłeś wypożyczenie książki o kolejny miesiąc!");
                }
                else
                {
                    Log.PrintErrorMessage("Dane, które podałeś są niepoprawne");
                }
            }
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            BorrowingList.Add(borrowing);
        }
        public int countingReaderBorrowings(int readerID)
        {
           int counter = 0;
           foreach(Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetReader().GetID() == readerID)
                {
                    counter++;
                }
            }
            return counter;
        }
        public List<Borrowing> removeBorrowingFromBorrowingList(Book b, Reader r)
        {
            List<Borrowing> temporaryList = new List<Borrowing>();
            bool isItEqual = false;
            foreach (Borrowing borrowing in BorrowingList)
            {
                if (borrowing.GetBook().Equals(b) && borrowing.GetReader().Equals(r))
                {
                    temporaryList.Add(borrowing);
                    isItEqual = true;
                }
            }
            if(isItEqual == false)
            {
                Log.PrintErrorMessage("Nie ma takiego wypożyczenia");
            }
            foreach(Borrowing tempBorrowing in temporaryList)
            {
                BorrowingList.Remove(tempBorrowing);
            }
            return BorrowingList;
        }
        public void findBookByCategory(string category)
        {
            List<Book> oneCategoryBooksList = new List<Book>();
           foreach(Book book in BooksList)
            {
                if (book.getCategory().Contains(category))
                {
                    oneCategoryBooksList.Add(book);
                }
            }
           foreach(Book book in oneCategoryBooksList)
            {
                Console.WriteLine(book);
            }
        }
        public void countAvailableBooks(string title)
        {
            Log.PrintInformationMessage("Dostępne książki do wypożyczenia:");
            int available = 0;
            bool isAvailable = false;
            foreach (Book book in BooksList)
            {
                if (book.GetTitle().Contains(title) && book.GetState() == Book.BookState.Available)
                {
                    Console.WriteLine(book);
                    available++;
                    isAvailable = true;
                }
            }
            if(isAvailable == false)
            {
                Log.PrintErrorMessage("Niestety nie ma książek o takim tytule na stanie");
            }
            Console.WriteLine($"Dostępnych książek o tym tytule jest: {available}");
            Console.WriteLine(" ");
        }
        public void countBookedBooks(string title)
        {
            int booked = 0;
            foreach (Book book in BooksList)
            {
                if (book.GetTitle().Contains(title) && book.GetState() == Book.BookState.Booked)
                {
                    booked++;
                }
            }
            Log.PrintInformationMessage($"Wypożyczonych ksiażek o tym tytule jest: {booked}");
        }
    }
}