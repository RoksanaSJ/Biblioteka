using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Employee : Person
    {
        int ID {  get; set; }
        int Age { get; set; }
        public Employee(string name, string surname, int age, int iD) : base(name, surname)
        {
            this.ID = iD;
            this.Age = age;
        }
        public string toString()
        {
            return "Pracownik: ID:" +ID + ", dane:" + Name + Surname;
        }
    }
}
