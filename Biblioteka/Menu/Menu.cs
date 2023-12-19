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
        const int OVERFLOW_VALUE = 9999;
        protected Library Library;
        public Menu(Library library)
        {
            this.Library = library;
        }
        public int ReadOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch (Exception e)
            {
                int overflow = OVERFLOW_VALUE;
                return overflow;
            }
        }
        public abstract void PrintMenu(); 
        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public void PrintInformationMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("");
        }
        //public void ConfirmOption(string message)
        //{
        //    Console.WriteLine(message);
        //    Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
        //}
    }
}
