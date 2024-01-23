using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    abstract class Repository<T>
    {
        protected List<T> ElementList { get; }
        protected Repository() 
        { 
            ElementList = new List<T>();
        }
        public List<T> Get()
        {
            return ElementList;
        }
        public void PrintList()
        {
            foreach (var item in ElementList)
            {
                Console.WriteLine(item);
            }
        }
        public void Add(T element)
        {
            ElementList.Add(element);
        }
    }
}
