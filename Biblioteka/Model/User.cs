using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class User : Person
    {
        protected int ID { get; }
        protected string Email {  get; set; }
        protected string Password { get; set; }

        public User(string name, string surname, string email, string password) : base(name, surname)
        {
            ID = IDGenerator.GenerateID();
            this.Email = email;
            this.Password = password;
        }
        public int GetID()
        {
            return ID;
        }       public string GetEmail()
        {
            return Email;
        }
        public string GetPassword()
        {
            return Password;
        }
        public void SetEmail(string usersEmail)
        {
            Email = usersEmail;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        public override string ToCSV()
        {
            return Name + "," + Surname + "," + ID + "," + Email + "," + Password;
        }
    }
}
