using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Readers
{
    internal class DeleteReader : Menu
    {
        public DeleteReader(Library library): base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID czytelnika: ");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine($"Czy ID, po którym chcesz usunąć czytelnika jest następujęce: {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    Reader reader = Library.GetReaderRepository().FindReaderByID(ID);
                    if(reader != null )
                    {
                        Library.GetReaderRepository().RemoveReader(reader);
                        Log.PrintSuccessMessage($"Gratulacje, właśnie usunąłeś czytelnika {reader.ToString()}");
                    }
                    else
                    {
                        Log.PrintErrorMessage("Nie ma w bazie czytelnika z takimi parametrami");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    continue;
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
