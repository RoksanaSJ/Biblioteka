using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class UserRepository
    {
        protected User CurrentUser { get; set; }
        protected List<User> UsersList { get; }
        public UserRepository() 
        { 
            UsersList = new List<User>();
        }
        public List<User> GetUsers()
        {
            return UsersList;
        }
        public User GetCurrentUser()
        {
            return CurrentUser;
        }
        public List<string> GetUsersEmails()
        {
            List<string> usersEmails = new List<string>();
            foreach (User user in UsersList)
            {
                usersEmails.Add(user.GetEmail());
            }
            return usersEmails;
        }
        public void SetCurrentUser(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
        public void ListUsers()
        {
            foreach (User users in UsersList)
            {
                Console.WriteLine(users);
            }
        }
        public void AddUser(User user)
        {
            UsersList.Add(user);
        }
    }
}
