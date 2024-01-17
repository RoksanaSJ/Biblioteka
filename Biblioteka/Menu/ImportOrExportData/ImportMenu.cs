using Biblioteka.Model;
using Biblioteka.Model.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ImportMenu : Menu
    {
        private ImportExport _importExport;
        public ImportMenu(Library library) : base(library)
        {
            _importExport = new ImportExport(library);
        }
        public override void PrintMenu()
        {
            Console.WriteLine("Importowane dane");
            Console.WriteLine("Podaj nazwę pliku zip do importu:");
            string zipFile = Console.ReadLine();
            if (!zipFile.EndsWith(".zip"))
            {
                zipFile = zipFile + ".zip";
            }
            _importExport.Import(zipFile);
        }
    }
}