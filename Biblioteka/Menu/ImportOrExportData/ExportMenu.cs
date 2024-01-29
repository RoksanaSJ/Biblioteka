using Biblioteka.Model;
using Biblioteka.Model.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ExportMenu : Menu
    {
        private ImportExport _importExport;
        public ExportMenu(Library library) : base(library)
        {
            _importExport = new ImportExport(library);
        }
        public override void PrintMenu()
        {
            Console.WriteLine("Eksportowane dane");
            try
            {
                Console.WriteLine("Podaj nazwę pliku zip:");
                string zipFile = Console.ReadLine();
                if (!zipFile.EndsWith(".zip"))
                {
                    zipFile = zipFile + ".zip";
                }
                _importExport.Export(zipFile);
            }
            catch (System.Exception e)
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
