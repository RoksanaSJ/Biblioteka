using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public void printErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public void printSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public void printInformationMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}
