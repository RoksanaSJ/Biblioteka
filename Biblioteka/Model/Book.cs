using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Book
    {
        protected Author author { get; }
        protected int ID { get; }
        protected string Title { get; }
        protected BookState state { get; set; }
        public Book(string name, string surname, string title)
        {
            ID = IDGenerator.generateID();
            Title = title;
            state = BookState.Available;
            author = new Author(name,surname);
        }
        public Author getAuthor()
        {
            return author;
        }
        public int getID()
        {
            return ID;
        }
        public string getTitle()
        {
            return Title;
        }
        public BookState getState()
        {
            return state;
        }
        public void booked()
        {
            state = BookState.Booked;
        }
        public void available()
        {
            state = BookState.Available;
        }
        public void setBookState(BookState bookState)
        {
            state = bookState;
        }
        public override string ToString()
        {
            return "Książka: ID:" + ID + ", tytuł: " + Title + ", autor: " + author.getName() + " " + author.getSurname();
        }
        public enum BookState
        {
            Available, Booked
        }
    }
}
