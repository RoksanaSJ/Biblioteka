using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Reader : Person
    {
        static int readerID = 1;
        int ID { get; set; }
        public int Age { get; set; }
        public Reader(string name, string surname, int age) : base(name, surname)
        {
            ID = readerID;
            readerID++;
            Age = age;
        }
        public override string ToString()
        {
            return "Czytelnik: ID: " + ID + ", imię i nazwisko: " + Name + " " + Surname + ", wiek: " + Age;
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
        public int getID()
        {
            return ID;
        }
    }
}
