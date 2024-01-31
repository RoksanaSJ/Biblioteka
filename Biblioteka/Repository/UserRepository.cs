using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class UserRepository : Repository<User>
    {
        protected User CurrentUser { get; set; }
        public UserRepository() 
        { 
           
        }
        public User GetCurrentUser()
        {
            return CurrentUser;
        }
        public List<string> GetUsersEmails()
        {
            List<string> usersEmails = new List<string>();
            foreach (User user in ElementList)
            {
                usersEmails.Add(user.GetEmail());
            }
            return usersEmails;
        }
        public User FindUserByCurrentUser(User currentUser)
        {
            foreach (User user in ElementList)
            {
                if (user.Equals(currentUser))
                {
                    return user;
                }
            }
            return null;
        }
        public User FindUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in ElementList)
            {
                if (user.GetEmail().Equals(email) && user.GetPassword().Equals(password))
                {
                    SetCurrentUser(user);
                    return user;
                }
            }
            return null;
        }
        public void SetCurrentUser(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
    }
}
