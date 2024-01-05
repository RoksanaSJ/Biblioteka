using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Charge
{
    internal class ChargeMenu : Menu
    {
        public ChargeMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Historia opłat danego czytelnika");
                Console.WriteLine("2.Tygodniowa historia opłat");
                Console.WriteLine("3.Miesięczna historia opłat");
                Console.WriteLine("4.Roczna historia opłat");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    Console.WriteLine("Podaj ID czytelnika:");
                    int ID = ReadOption();
                    Console.WriteLine("");
                    Library.ChargeInformationForSpecificReader(ID);
                }
                else if (option == 2)
                {
                    //TODO
                }
                else if (option == 3)
                {
                    //TODO
                }
                else if (option == 4)
                {
                    //TODO
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj właściwą opcję!");
                }
            }
        }
    }
}
