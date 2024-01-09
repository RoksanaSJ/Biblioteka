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
        private AddReaderMenu _addReaderInit;
        private DeleteRerader _removeReaderInit;
        private ReaderInformation _readerInformationInit;
        public ReaderMenu(Library library) : base(library)
        {
            _addReaderInit = new AddReaderMenu(library);
            _removeReaderInit = new DeleteRerader(library);
            _readerInformationInit = new ReaderInformation(library);
        }
        public override void PrintMenu()
        {
            while (true)
            {
                //Console.WriteLine("1.Dodaj czytelnika");
                Console.WriteLine("1.Usuń czytelnika");
                Console.WriteLine("2.Wypisz wszystkich czytelników");
                Console.WriteLine("3.Wypisz wszystkie powiązane rekordy z wyszukanym czytelnikiem");
                Console.WriteLine("4.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                Console.WriteLine(" ");
                //if (option == 1)
                //{
                //    _addReaderInit.PrintMenu();
                //    Console.WriteLine("");
                //}
                /*else*/ if (option == 1)
                {
                    _removeReaderInit.PrintMenu();
                    Console.WriteLine("");
                }
                else if (option == 2)
                {
                    Log.PrintInformationMessage("Lista czytelników:");
                    Library.ListTheReaders();
                    Console.WriteLine("");
                }
                else if (option == 3)
                {
                    Log.PrintInformationMessage("Wszytskie rekordy powiązane z cztelnikiem:");
                    _readerInformationInit.PrintMenu();
                    Console.WriteLine("");
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj prawidłową opcję!");
                }
            }
        }
    }
}
