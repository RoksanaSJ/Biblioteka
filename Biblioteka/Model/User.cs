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
        private string Email {  get; set; }
        private string Password { get; set; }
        private UserRole UserRole { get; }
        private bool RequiredPasswordChange { get; set; }
        public User(string email, string password, UserRole userRole)
        {
            this.Email = email;
            this.Password = password;
            this.UserRole = userRole;
            this.RequiredPasswordChange = false;
        }
        public User(string email, string password, UserRole userRole, bool RequiredPasswordChange)
        {
            this.Email = email;
            this.Password = password;
            this.UserRole = userRole;
            this.RequiredPasswordChange = true;
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
        public bool GetInfoAboutPassword()
        {
            return RequiredPasswordChange;
        }
        public void SetEmail(string usersEmail)
        {
            Email = usersEmail;
        }
        public void SetPassword(string password)
        {
            Password = password;
            SetIfPasswordIsNotNeededToBeChanged();
        }
        public void SetIfPasswordIsNeededToBeChanged()
        {
            RequiredPasswordChange = true;
        }
        public void SetIfPasswordIsNotNeededToBeChanged()
        {
            RequiredPasswordChange = false;
        }
        public override string ToString()
        {
            return "Email: " + Email + " Rola: " + UserRole;
        }

        public override string ToCSV()
        {
            return Email + "," + Password + "," + UserRole + "," + RequiredPasswordChange;
        }
    }
}
