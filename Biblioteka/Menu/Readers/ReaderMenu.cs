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

        public void printReaderMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("2.Wypisz wszystkich czytelników");
                Console.WriteLine("3.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = readOption();
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
        public int readOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch (Exception e)
            {
                int overflow = 9999;
                return overflow;
            }
        }
    }
}
