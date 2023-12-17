using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ImportExportMenu : Menu
    {
        ImportMenu importMenu;
        ExportMenu exportMenu;
        public ImportExportMenu(Library library) : base(library)
        {
            importMenu = new ImportMenu(library);
            exportMenu = new ExportMenu(library);
        }

        public override void printMenu()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1.Import danych");
                Console.WriteLine("2.Export danych");
                Console.WriteLine("Podaj opcję: ");
                int option = readOption();
                Console.WriteLine("");
                if (option == 1)
                {
                    importMenu.printMenu();
                }
                else if (option == 2)
                {
                    exportMenu.printMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Podaj prawidłową opcję!");
                    Console.ResetColor();
                }
            }
        }
    }
}
