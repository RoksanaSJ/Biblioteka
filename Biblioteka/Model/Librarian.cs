using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Librarian : Person
    {
        protected int ID { get; }
        protected int Age { get; }
        protected User User { get; }
        public Librarian(string name, string surname, int age, int ID, User user) : base(name, surname)
        {
            this.ID = ID;
            Age = age;
            User = user;
        }
        public Librarian(string name, string surname, int age) : base(name, surname)
        {
            ID = IDGenerator.GenerateID();
            Age = age;
        }
        public Librarian(string name, string surname, int age, User user) : base(name, surname)
        {
            ID = IDGenerator.GenerateID();
            Age = age;
            User = user;
        }
        public int GetID()
        {
            return ID;
        }
        public int GetAge()
        {
            return Age;
        }
        public User GetUser()
        {
            return User;
        }
        public override string ToString()
        {
            return "Pracownik: ID: " + ID + ", dane: " + Name + " "+ Surname + ", wiek: " + Age;
        }
        public override string ToCSV()
        {
            return ID + "," + Name +","+ Surname + "," + Age + "," + User.GetEmail();
        }
    }
}
