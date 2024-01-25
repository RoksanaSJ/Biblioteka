using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ReturningRepository : Repository<Returning>
    {
        public ReturningRepository() 
        {
            
        }
        public void ReturnBook(Book book, Reader reader)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, book, reader);
            ElementList.Add(ret);
            book.Available();
        }
        public Returning FindReturningsByReaderID(int readerID)
        {
            foreach(Returning returning in ElementList)
            {
                if(returning.GetReader().GetID() == readerID)
                {
                    return returning;
                }
            }
            return null;
        }
        public Returning FindReturningsByCurrentUser(User currentUser)
        {
            foreach (Returning returning in ElementList)
            {
                if (returning.GetReader().GetUser().Equals(currentUser))
                {
                    return returning;
                }
            }
            return null;
        }
    }
}
