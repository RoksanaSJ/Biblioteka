using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ExportMenu : Menu
    {
        public ExportMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            Console.WriteLine("Eksportowane dane");

            // string createText = "Hello and Welcome" + Environment.NewLine;
            // File.WriteAllText(path, createText);
            //-------------------------------
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0");
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
