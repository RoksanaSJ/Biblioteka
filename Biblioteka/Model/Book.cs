using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Book : Record
    {
        protected Author Author { get; }
        protected int ID { get; }
        protected string Title { get; }
        protected BookState State { get; set; }
        protected HashSet<String> Categories { get; set; }
        public Book(string name, string surname, string title, int ID, BookState state, HashSet<String> categories) : base()
        {
            this.ID = ID;
            Title = title;
            this.State = state;
            Author = new Author(name, surname);
            Categories = categories;
        }
        public Book(string name, string surname, string title) : base()
        {
            ID = IDGenerator.GenerateID();
            Title = title;
            State = BookState.Available;
            Author = new Author(name,surname);
            Categories = new HashSet<string>();
        }
        public Book(string name, string surname, string title, HashSet<String> categories) : base()
        {
            ID = IDGenerator.GenerateID();
            Title = title;
            State = BookState.Available;
            Author = new Author(name, surname);
            Categories = categories;
        }
        public Author GetAuthor()
        {
            return Author;
        }
        public int GetID()
        {
            return ID;
        }
        public string GetTitle()
        {
            return Title;
        }
        public HashSet<string> getCategory()
        {
            return Categories;
        }
        public BookState GetState()
        {
            return State;
        }
        public void Booked()
        {
            State = BookState.Booked;
        }
        public void Available()
        {
            State = BookState.Available;
        }
        public void SetBookState(BookState bookState)
        {
            State = bookState;
        }
        public override string ToString()
        {
            return "Książka: ID:" + ID + ", tytuł: " + Title + ", autor: " + Author.GetName() + " " + Author.GetSurname() + ", status: " + GetState() +", kategoria: " + string.Join(", ", Categories);
        }
        public override string ToCSV()
        {
            return ID + "," + Title + "," + Author.GetName() + "," + Author.GetSurname() + "," + State + "," + string.Join(";", Categories);
        }
        public enum BookState
        {
            Available, Booked
        }
    }
}
