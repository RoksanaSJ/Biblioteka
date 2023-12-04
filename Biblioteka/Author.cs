using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Author: Person
    {
        public Author (string name, string surname) : base(name, surname)
        {

        }
        public override string ToString()
        {
            return "Autor: " + Name + Surname;
        }
        public string getAuthor()
        {
            return Name+" "+Surname;
        }
    }
}
