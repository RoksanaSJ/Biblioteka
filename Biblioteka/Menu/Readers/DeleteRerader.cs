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
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                   List<Reader> list = library.getReaders();
                   bool isItEquals = false;
                   List<Reader> toRemove = new List<Reader>();
                    foreach (var reader in list)
                    {
                        if (reader.getName().Equals(name) && reader.getSurname().Equals(surname) && reader.getAge().Equals(age))
                        {
                            toRemove.Add(reader);
                            isItEquals = true;
                        }
                    }
                    if (isItEquals == false)
                    {
                        printErrorMessage("Nie ma w bazie czytelnika z takimi parametrami");
                    }
                    foreach(var reader in toRemove)
                    {
                        list.Remove(reader);
                        printSuccessMessage($"Gratulacje, właśnie usunąłeś czytelnika {reader.ToString()}");
                    }
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    printMenu();
                    Console.WriteLine("");
                }
                else if (userOption.Equals("b"))
                {
                    break;
                }
                else
                {
                    printErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
