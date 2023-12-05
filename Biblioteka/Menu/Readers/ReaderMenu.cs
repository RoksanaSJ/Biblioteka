using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Readers
{
    internal class ReaderMenu
    {
        Library library;
        AddReaderMenu addReaderInit;
        public ReaderMenu(Library library)
        {
            this.library = library;
            addReaderInit = new AddReaderMenu(library);
        }

        public void printReaderMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("2.Wypisz wszystkich czytelników");
                Console.WriteLine("3.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addReaderInit.addReaderMenu();
                        break;
                    case 2:
                        library.listTheReaders();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Podaj prawidłową opcję!");
                        break;
                }
            }
        }
    }
}
