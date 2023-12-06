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
        public void addReaderMenu()
        {
            Console.WriteLine("Podaj imię: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Podaj wiek: ");
            int age = int.Parse(Console.ReadLine());

            Reader reader = new Reader(name, surname, age);
            library.addReader(reader);
        }
    }
}
