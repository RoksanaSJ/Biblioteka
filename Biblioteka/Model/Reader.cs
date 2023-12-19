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
        protected int ID { get; }
        protected int Age { get; set; }
        public Reader(string name, string surname, int age) : base(name, surname)
        {
            ID = IDGenerator.generateID();
            Age = age;
        }
        public Reader(int ID, string name, string surname, int age) : base(name, surname)
        {
            this.ID = ID;
            Age = age;
        }
        public int getID()
        {
            return ID;
        }
        public int getAge()
        {
            return Age;
        }
        public void setAge(int readersAge)
        {
            Age = readersAge;
        }
        public bool isOfAge(int age)
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
        public override string toCSV()
        {
            return  ID + "," + Name + "," + Surname + "," + Age;
        }
    }
}
