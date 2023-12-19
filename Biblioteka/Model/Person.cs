using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public abstract class Person : Record
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        public Person(string name, string surname) : base()
        {
            Name = name;
            Surname = surname;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetSurname()
        {
            return Surname;
        }
        public void SetName(string personsName)
        {
            Name = personsName;
        }
        public void SetSurname(string personsSurname)
        {
            Surname = personsSurname;
        }
    }
}
