using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Book : Author
    {
        static int nextID = 1;
        int ID { get; set; }
        string Title { get; set; }

        BookState state { get; set; }
        public Book(string name, string surname, string title) : base(name, surname)
        {
            ID = nextID;
            nextID++;
            Title = title;
            state = BookState.Available;
        }
        public override string ToString()
        {
            return "Książka: ID:" + ID + ", tytuł: " + Title + ", autor: " + Name + " " + Surname;
        }
        public string getTitle()
        {
            return Title;
        }
        public int getID()
        {
            return ID;
        }
        public enum BookState
        {
            Available, Booked
        }
        public void booked()
        {
            state = BookState.Booked;
        }
        public void available()
        {
            state = BookState.Available;
        }

        public BookState getState()
        {
            return state;
        }
    }
}
