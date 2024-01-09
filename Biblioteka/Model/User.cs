using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class User : Record
    {
        protected string Email {  get; set; }
        protected string Password { get; set; }
        protected UserRole UserRole { get; }
        public User(string email, string password, UserRole userRole)
        {
            this.Email = email;
            this.Password = password;
            UserRole = userRole;
        }
        public string GetEmail()
        {
            return Email;
        }
        public string GetPassword()
        {
            return Password;
        }
        public UserRole GetUserRole()
        {
            return UserRole;
        }
        public void SetEmail(string usersEmail)
        {
            Email = usersEmail;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        //TODO toString();
        public override string ToString()
        {
            return "Email: " + Email + " Rola: " + UserRole;
        }
        public override string ToCSV()
        {
            return Email + "," + Password + "," + UserRole;
        }
    }
}
