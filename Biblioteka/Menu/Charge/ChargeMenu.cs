﻿using System;
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
                Console.WriteLine("2.Historia opłat z danego okresu");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    Console.WriteLine("Podaj ID czytelnika:");
                    int ID = ReadOption();
                    Console.WriteLine("");
                    bool found = Library.GetChargeInformationRepository().ChargeInformationForSpecificReader(ID);
                    if(found == false)
                    {
                        Log.PrintErrorMessage("Dany czytelnik nie został obciążony żadną opłatą");
                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Podaj datę początkową w formacie yyyy-MM-dd:");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj datę końcową w formacie yyyy-MM-dd:");
                    DateTime finishDate = DateTime.Parse(Console.ReadLine() + " 23:59:59");
                    if(Library.GetChargeInformationRepository().CheckIfStartDateIsEarlierThanFinishDate(startDate,finishDate) == false)
                    {
                        Log.PrintErrorMessage("Data końcowa powinna być późniejsza niż początkowa");
                    }
                    else
                    {
                        Library.GetChargeInformationRepository().PrintHistoryFromPeriod(startDate, finishDate);
                    }
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
