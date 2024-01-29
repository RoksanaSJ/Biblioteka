using Biblioteka.ConsoleMessage;
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
        protected ConsoleLog Log;
        public Menu(Library library)
        {
            this.Library = library;
            this.Log = new ConsoleLog();
        }
        public int ReadOption()
        {
            try
            {
                int option = int.Parse(Console.ReadLine());
                return option;
            }
            catch (System.Exception e)
            {
                int overflow = OVERFLOW_VALUE;
                return overflow;
            }
        }
        public abstract void PrintMenu();
    }
}
