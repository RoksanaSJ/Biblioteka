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
        public override void printMenu()
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
                char userOption = char.Parse(Console.ReadLine());
                if (userOption == 'y')
                {
                    Reader reader = new Reader(name, surname, age);
                    library.addReader(reader);
                }
                else if (userOption == 'n')
                {
                    printMenu();
                }
                else if (userOption == 'b')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną opcję!");
                }
            }
            Console.WriteLine(" ");
        }
    }
}
