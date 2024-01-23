using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ReturningRepository
    {
        protected List<Returning> ReturningList { get; }
        public ReturningRepository() 
        {
            ReturningList = new List<Returning>();
        }
        public List<Returning> GetReturnings()
        {
            return ReturningList;
        }
        public void ListTheReturnings()
        {
            foreach (var item in ReturningList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddReturning(Returning returning)
        {
            ReturningList.Add(returning);
        }
        public void ReturnBook(Book book, Reader reader)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            Returning ret = new Returning(date, book, reader);
            ReturningList.Add(ret);
            book.Available();
        }
    }
}
