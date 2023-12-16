using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ImportMenu : Menu
    {
        public ImportMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            Console.WriteLine("Importowane dane");

            // string readText = File.ReadAllText(path);
            //-------------

            //Read a Text File
            //static void Main(string[] args)
            //{
                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0");
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        Console.WriteLine(line);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
           // }
        }
    }
}
