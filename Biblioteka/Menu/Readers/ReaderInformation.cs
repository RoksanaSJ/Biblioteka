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
                List<Returning> readerReturnings = new List<Returning>();
                readerReturnings = library.getReturnings();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dane użytkownika: ");
                Console.ResetColor();
                Console.WriteLine(" ");
                foreach (var reader in readerInfo)
                {
                    if(reader.getID() == readID)
                    {
                        Console.WriteLine(reader);
                    }
                }
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Wypożyczenia użytkowanika: ");
                Console.ResetColor();
                Console.WriteLine(" ");
                foreach (var borrowing in borrowings)
                {
                    if(borrowing.getReader().getID() == readID)
                    {
                        Console.WriteLine(borrowing);
                    }
                }
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Historia wypożyczeń użytkowanika: ");
                Console.ResetColor();
                Console.WriteLine(" ");
                foreach (var returning in readerReturnings)
                {
                    if (returning.getReader().getID() == readID)
                    {
                        Console.WriteLine(returning);
                    }
                }
                break;
            }
        }
    }
}
