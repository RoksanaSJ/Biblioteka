using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Repository
{
    internal class ReaderRepository
    {
        protected List<Reader> ReadersList { get; }
        public ReaderRepository() 
        {
            ReadersList = new List<Reader>();
        }
        public List<Reader> GetReaders()
        {
            return ReadersList;
        }
        public Reader FindReaderByID(int ID)
        {
            foreach (Reader reader in ReadersList)
            {
                if (reader.GetID() == ID)
                {
                    return reader;
                }
            }
            return null;
        }
        public void ListTheReaders()
        {
            foreach (var item in ReadersList)
            {
                Console.WriteLine(item);
            }
        }
        public void AddReader(Reader c)
        {
            ReadersList.Add(c);
        }
        public void RemoveReader(Reader c)
        {
            ReadersList.Remove(c);
        }
    }
}
