using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Author : Person
    {
        public Author(string name, string surname) : base(name, surname)
        {

        }
        public string GetNameAndSurname()
        {
            return Name + " " + Surname;
        }
        public override string ToString()
        {
            return "Autor: " + Name + Surname;
        }
        public override string ToCSV()
        {
            return Name + "," + Surname;
        }
    }
}
