using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Readers
{
    internal class ReaderInformation : Menu
    {
        public ReaderInformation(Library library): base(library)
        { 

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID wyszukiwanego czytelnika: ");
                int readID = ReadOption();
                List<Reader> readerInfo = new List<Reader>();
                readerInfo = Library.GetReaders();
                List<Borrowing> borrowings = new List<Borrowing>();
                borrowings = Library.GetBorrowings();
                List<Returning> readerReturnings = new List<Returning>();
                readerReturnings = Library.GetReturnings();
                Log.PrintInformationMessage("Dane użytkownika: ");
                foreach (Reader reader in readerInfo)
                {
                    if(reader.GetID() == readID)
                    {
                        Console.WriteLine(reader);
                    }
                }
                Console.WriteLine("");
                Log.PrintInformationMessage("Wypożyczenia użytkowanika: ");
                foreach (Borrowing borrowing in borrowings)
                {
                    if(borrowing.GetReader().GetID() == readID)
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                Console.WriteLine("");
                Log.PrintInformationMessage("Historia wypożyczeń użytkowanika: ");
                foreach (Returning returning in readerReturnings)
                {
                    if (returning.GetReader().GetID() == readID)
                    {
                        Console.WriteLine(returning);
                    }
                }
                break;
            }
        }
    }
}
