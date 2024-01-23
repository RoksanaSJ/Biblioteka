using Biblioteka.Menu.Books;
using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class BookRepository : Repository<Book>
    {
        public BookRepository()
        {

        }
        public Book FindBookByID(int ID)
        {
            foreach (Book book in ElementList)
            {
                if (book.GetID() == ID)
                {
                    return book;
                }
            }
            return null;
        }
        public List<Book> FindBooksByCategory(string category)
        {
            List<Book> oneCategoryBooksList = new List<Book>();
            foreach (Book book in ElementList)
            {
                if (book.getCategory().Contains(category))
                {
                    oneCategoryBooksList.Add(book);
                }
            }
            return oneCategoryBooksList;
        }
        public List<Book> FindBooksByAuthor(string fullName)
        {
            List<Book> oneAuthorBooks = new List<Book>();
            foreach (var book in ElementList)
            {
                if (book.GetAuthor().GetNameAndSurname().Contains(fullName))
                {
                    oneAuthorBooks.Add(book);
                }
            }
            return oneAuthorBooks;
        }
        public List<Book> GetBooksByState(string title,Book.BookState state)
        {
            List<Book> books = new List<Book>();
            foreach (Book book in ElementList)
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
        public void RemoveBook(Book book)
        {
            ElementList.Remove(book);
        }
    }
}
