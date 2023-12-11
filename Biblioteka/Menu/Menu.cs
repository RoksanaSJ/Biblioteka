using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu
{
    abstract class Menu
    {
       protected Library library;
        public Menu(Library library)
        {
            this.library = library;
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
        public abstract void printMenu(); 
    }
}
