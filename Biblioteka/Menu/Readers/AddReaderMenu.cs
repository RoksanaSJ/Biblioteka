using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;
using static Biblioteka.Model.Reader;

namespace Biblioteka.Menu.Readers
{
    internal class AddReaderMenu : Menu
    {
        public AddReaderMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Podaj wiek: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine($"Czy twoje dane są następujące: imię: {name}, nazwisko: {surname}, wiek: {age}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Reader reader = new Reader(name, surname, age);
                    Log.PrintSuccessMessage($"Gratulacje właśnie dodałeś użytkowanika {reader.ToString()}");
                    Library.AddReader(reader);
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    PrintMenu();
                    Console.WriteLine("");
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
