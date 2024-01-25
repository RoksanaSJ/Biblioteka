using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository() 
        {

        }
        public Reader FindReaderByID(int ID)
        {
            foreach (Reader reader in ElementList)
            {
                if (reader.GetID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public Reader FindReaderByCurrentUser(User currentUser)
        {
            foreach (Reader reader in ElementList)
            {
                if (reader.GetUser().Equals(currentUser))
                {
                    return reader;
                }
            }
            return null;
        }
        public void RemoveReader(Reader reader)
        {
            ElementList.Remove(reader);
        }
    }
}
