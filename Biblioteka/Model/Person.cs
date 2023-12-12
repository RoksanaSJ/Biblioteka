using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Person
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string getName()
        {
            return Name;
        }
        public string getSurname()
        {
            return Surname;
        }
        public void setName(string personsName)
        {
            Name = personsName;
        }
        public void setSurname(string personsSurname)
        {
            Surname = personsSurname;
        }
    }
}
