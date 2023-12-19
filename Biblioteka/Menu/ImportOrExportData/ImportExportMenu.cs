using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ImportExportMenu : Menu
    {
        private ImportMenu _importMenu;
        private ExportMenu _exportMenu;
        public ImportExportMenu(Library library) : base(library)
        {
            _importMenu = new ImportMenu(library);
            _exportMenu = new ExportMenu(library);
        }

        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1.Export danych");
                Console.WriteLine("2.Import danych");
                Console.WriteLine("3.Wróć");
                Console.WriteLine("Podaj opcję: ");
                int option = ReadOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    _exportMenu.PrintMenu();
                }
                else if (option == 2)
                {
                    _importMenu.PrintMenu();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    PrintErrorMessage("Podaj prawidłową opcję!");
                }
            }
        }
    }
}
