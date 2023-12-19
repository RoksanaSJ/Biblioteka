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
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID wyszukiwanego czytelnika: ");
                int readID = int.Parse(Console.ReadLine());
                List<Reader> readerInfo = new List<Reader>();
                readerInfo = Library.GetReaders();
                List<Borrowing> borrowings = new List<Borrowing>();
                borrowings = Library.GetBorrowings();
                List<Returning> readerReturnings = new List<Returning>();
                readerReturnings = Library.GetReturnings();
                PrintInformationMessage("Dane użytkownika: ");
                foreach (var reader in readerInfo)
                {
                    if(reader.GetID() == readID)
                    {
                        Console.WriteLine(reader);
                    }
                }
                Console.WriteLine("");
                PrintInformationMessage("Wypożyczenia użytkowanika: ");
                foreach (var borrowing in borrowings)
                {
                    if(borrowing.GetReader().GetID() == readID)
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                Console.WriteLine("");
                PrintInformationMessage("Historia wypożyczeń użytkowanika: ");
                foreach (var returning in readerReturnings)
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
