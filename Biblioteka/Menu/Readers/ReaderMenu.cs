using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Readers
{
    internal class ReaderMenu : Menu
    {
        AddReaderMenu addReaderInit;
        DeleteRerader removeReaderInit;
        public ReaderMenu(Library library) : base(library)
        {
            addReaderInit = new AddReaderMenu(library);
            removeReaderInit = new DeleteRerader(library);
        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("2.Usuń czytelnika");
                Console.WriteLine("3.Wypisz wszystkich czytelników");
                Console.WriteLine("4.Wróć");
                Console.WriteLine("Podaj opcję: ");
                Console.WriteLine(" ");
                int option = readOption();
                if (option == 1)
                {
                    addReaderInit.printMenu();
                }
                else if (option == 2)
                {
                    removeReaderInit.printMenu();
                }
                else if (option == 3)
                {
                    library.listTheReaders();
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj prawidłową opcję!");
                }
            }
            Console.WriteLine(" ");
        }
    }
}
