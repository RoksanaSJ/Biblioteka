using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class LibrarianRepository : Repository<Librarian>
    {
        public LibrarianRepository()
        {
           
        }
        public Librarian FindLibrarianByID(int ID)
        {
            foreach(Librarian librarian in ElementList)
            {
                if(librarian.GetID() == ID)
                {
                    return librarian;
                }
            }
            return null;
        }
        public Librarian FindLibrarianByFullname(string name, string surname)
        {
            foreach (Librarian librarian in ElementList)
            {
                if (librarian.GetName().Equals(name) && librarian.GetSurname().Equals(surname))
                {
                    return librarian;
                }
            }
            return null;
        }
        public void RemoveLibrarian(Librarian librarian)
        {
            ElementList.Remove(librarian);
        }
    }
}
