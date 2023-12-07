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
        public ReaderMenu(Library library) : base(library)
        {
            addReaderInit = new AddReaderMenu(library);
        }
        public void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("2.Wypisz wszystkich czytelników");
                Console.WriteLine("3.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = readOption();
                if (option == 1)
                {
                    addReaderInit.addReaderMenu();
                }
                else if (option == 2)
                {
                    library.listTheReaders();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj prawidłową opcję!");
                }
            }
            Console.WriteLine("");
        }
    }
}
