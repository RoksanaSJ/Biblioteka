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
        ReaderInformation readerInformationInit;
        public ReaderMenu(Library library) : base(library)
        {
            addReaderInit = new AddReaderMenu(library);
            removeReaderInit = new DeleteRerader(library);
            readerInformationInit = new ReaderInformation(library);
        }
        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("2.Usuń czytelnika");
                Console.WriteLine("3.Wypisz wszystkich czytelników");
                Console.WriteLine("4.Wypisz wszystkie powiązane rekordy z wyszukanym czytelnikiem");
                Console.WriteLine("5.Wróć");
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
                    readerInformationInit.printMenu();
                }
                else if (option == 5)
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
