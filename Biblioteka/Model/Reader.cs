using Biblioteka.Model.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Reader : Person
    {
        private int ID { get; }
        private int Age { get; set; }
        private User LibraryUser { get; } 
        public Reader(string name, string surname, int age, User libraryUser) : base(name, surname)
        {
            ID = IDGenerator.GenerateID();
            Age = age;
            LibraryUser = libraryUser;
        }
        public Reader(int ID, string name, string surname, int age, User libraryUser) : base(name, surname)
        {
            this.ID = ID;
            Age = age;
            LibraryUser = libraryUser;
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
            return LibraryUser;
        }
        public void SetAge(int readersAge)
        {
            Age = readersAge;
        }
        public static bool IsOfAge(int age)
        {
            if (age > 18)
            {
                Console.WriteLine("Czytelnik jest pełnoletni");
                return true;
            }
            else
            {
                Console.WriteLine("Czytelnik nie jest pełnoletni");
                return false;
            }
        }
        public override string ToString()
        {
            return "Czytelnik: ID: " + ID + ", imię i nazwisko: " + Name + " " + Surname + ", wiek: " + Age;
        }
        public override string ToCSV()
        {
            return  ID + "," + Name + "," + Surname + "," + Age + "," + LibraryUser.GetEmail();
        }
    }
}
