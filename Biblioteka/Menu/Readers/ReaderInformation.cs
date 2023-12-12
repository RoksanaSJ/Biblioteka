using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Readers
{
    internal class ReaderInformation : Menu
    {
        public ReaderInformation(Library library): base(library)
        { 

        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID wyszukiwanego czytelnika: ");
                int readID = int.Parse(Console.ReadLine());
                List<Reader> readerInfo = new List<Reader>();
                readerInfo = library.getReaders();
                List<Biblioteka.Model.Borrowing> borrowings = new List<Biblioteka.Model.Borrowing>();
                borrowings = library.getBorrowings();
                Console.WriteLine("Dane użytkownika: ");
                Console.WriteLine(" ");
                foreach (var reader in readerInfo)
                {
                    if(reader.getID() == readID)
                    {
                        Console.WriteLine(reader);
                    }
                }
                Console.WriteLine("Wypożyczenia użytkowanika: ");
                Console.WriteLine(" ");
                foreach (var borrowing in borrowings)
                {
                    if(borrowing.getReader().getID() == readID)
                    {
                        Console.WriteLine(borrowing);
                    }
                }

            }
        }
    }
}
