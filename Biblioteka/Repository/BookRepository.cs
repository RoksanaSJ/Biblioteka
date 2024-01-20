using Biblioteka.Menu.Books;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class BookRepository
    {
        protected List<Book> BooksList { get; }
        public BookRepository()
        {
            BooksList = new List<Book>();
        }
        public List<Book> GetBooks()
        {
            return BooksList;
        }
        public Book FindBookByID(int ID)
        {
            foreach (Book book in BooksList)
            {
                if (book.GetID() == ID)
                {
                    return book;
                }
            }
            return null;
        }
        public List<Book> FindBookByCategory(string category)
        {
            List<Book> oneCategoryBooksList = new List<Book>();
            foreach (Book book in BooksList)
            {
                if (book.getCategory().Contains(category))
                {
                    oneCategoryBooksList.Add(book);
                }
            }
            return oneCategoryBooksList;
        }
        public List<Book> FindBookByAuthor(string fullName)
        {
            List<Book> oneAuthorBooks = new List<Book>();
            foreach (var book in BooksList)
            {
                if (book.GetAuthor().GetNameAndSurname().Contains(fullName))
                {
                    oneAuthorBooks.Add(book);
                }
            }
            return oneAuthorBooks;
        }
        public void ListTheBooks()
        {
            foreach (var item in BooksList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddBook(Book k)
        {
            BooksList.Add(k);
        }
        public List<Book> GetBooksByState(string title,Book.BookState state)
        {
            List<Book> books = new List<Book>();
            foreach (Book book in BooksList)
            {
                if (book.GetTitle().Contains(title) && book.GetState() == state)
                {
                    books.Add(book);
                }
            }
            return books;
        }
        public List<Book> GetAvailableBooks(string title)
        {
            return GetBooksByState(title, Book.BookState.Available);
        }
        public List<Book> GetBookedBooks(string title)
        {
            return GetBooksByState(title, Book.BookState.Booked);
        }
    }
}
