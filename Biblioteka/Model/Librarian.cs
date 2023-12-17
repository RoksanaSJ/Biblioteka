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
        public Librarian(string name, string surname, int age) : base(name, surname)
        {
            ID = IDGenerator.generateID();
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
        public override string ToString()
        {
            return "Pracownik: ID: " + ID + ", dane: " + Name + " "+ Surname + ", wiek: " + Age;
        }
        public override string toCSV()
        {
            return ID + "," + Name +","+ Surname + "," + Age;
        }
    }
}
