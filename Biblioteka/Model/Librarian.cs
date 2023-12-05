using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Librarian : Person
    {
        int ID { get; set; }
        int Age { get; set; }
        public Librarian(string name, string surname, int age, int iD) : base(name, surname)
        {
            ID = iD;
            Age = age;
        }
        public string toString()
        {
            return "Pracownik: ID:" + ID + ", dane:" + Name + Surname;
        }
    }
}
