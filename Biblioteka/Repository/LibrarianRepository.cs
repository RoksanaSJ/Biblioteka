using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class LibrarianRepository
    {
        protected List<Librarian> LibrarianList { get; }
        public LibrarianRepository()
        {
            LibrarianList = new List<Librarian>();
        }
        public List<Librarian> GetLibrarians()
        {
            return LibrarianList;
        }
        public void ListTheLibrarians()
        {
            foreach (var item in LibrarianList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddLibrarian(Librarian p)
        {
            LibrarianList.Add(p);
        }
    }
}
