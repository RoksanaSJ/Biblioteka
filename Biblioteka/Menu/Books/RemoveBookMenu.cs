using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class RemoveBookMenu : Menu
    {
        public RemoveBookMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true) 
            { 
                Console.WriteLine("Podaj ID książki, którą chcesz usunąć");
                int ID = ReadOption();
                Book bookFound = Library.GetBookRepository().FindBookByID(ID);
                if (bookFound != null)
                {
                    Console.WriteLine($"\nCzy to jest ta ksiażka, którą chcesz usunąć? {bookFound}?");
                    Console.WriteLine("Wpisz 'y' jeśli tak, 'n' jeśli nie 'b' jeśli chcesz wrócić");
                    string option = Console.ReadLine();
                    if (option.Equals("y"))
                    {
                        Library.GetBookRepository().RemoveBook(bookFound);
                        Log.PrintSuccessMessage($"Gratulację, właśnie usunąleś książkę {bookFound}");
                        break;
                    }
                    else if (option.Equals("n"))
                    {
                        continue;
                    }
                    else if (option.Equals("b"))
                    {
                        break;
                    }
                    else
                    {
                        Log.PrintErrorMessage("Podaj właściwą opcję!");
                    }
                }
                else
                {
                    Log.PrintErrorMessage("Nie znaleziono książki o takim ID");
                }
            }
        }
    }
}
