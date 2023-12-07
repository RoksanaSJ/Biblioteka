﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchBookMenu : Menu
    {
        private SearchByAuthorMenu searchByAuthorMenu;
        private SearchByTitleMenu searchByTitleMenu;
        public SearchBookMenu(Library library) : base(library)
        {
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
        }

        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Wyszukaj po autorze");
                Console.WriteLine("2.Wyszukacj po tytule");
                Console.WriteLine("3. Wróć");
                Console.WriteLine("Podaj opcję: ");
                int choose = readOption();
                if (choose == 1)
                {
                    searchByAuthorMenu.printMenu();
                }
                else if (choose == 2)
                {
                    searchByTitleMenu.printMenu();
                }
                else if (choose == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
            Console.WriteLine("");
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
