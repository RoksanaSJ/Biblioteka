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
        public void SetCurrentUser(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
    }
}
