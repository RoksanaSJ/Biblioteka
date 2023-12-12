using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Readers
{
    internal class DeleteRerader : Menu
    {
        public DeleteRerader(Library library): base(library)
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
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                   Reader reader = new Reader(name, surname, age); //?
                   if(library.getLiblarians().Equals(reader))
                    {
                        library.removeReader(reader);
                        Console.WriteLine($"Gratulacje, właśnie usunąłeś czytelnika {reader.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Nie ma w bazie czytelnika z takimi parametrami");
                    }
                }
                else if (userOption.Equals("n"))
                {
                    printMenu();
                }
                else if (userOption.Equals("b"))
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
