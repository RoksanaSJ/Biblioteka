using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class AddBookMenu : Menu
    {
        public AddBookMenu(Library library) : base(library)
        {
           
        }
        public override void PrintMenu()
        {
            while (true)
            {
                DateTime borrowingDate = new DateTime();
                DateTime returningDate = new DateTime();
                returningDate = DateTime.Now;
                TimeSpan timeSpan = new TimeSpan();
                Console.WriteLine(timeSpan = returningDate - borrowingDate);
                Console.WriteLine("");
                Console.WriteLine("Podaj tytuł książki: ");
                string title = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Podaj imię autora: ");
                string name = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Podaj nazwisko autora: ");
                string surname = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine($"Czy książka, którą chcesz dodać ma następujące parametry: Tytuł: {title}, Autor: {name} {surname}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    Book book = new Book(name, surname, title);
                    Library.AddBook(book);
                    PrintSuccessMessage(($"Gratulację! Udało ci się dodać książkę: Tytuł: {title}, Autor: {name} {surname}"));
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    PrintMenu();
                    Console.WriteLine(" ");
                } else if (userOption.Equals("b"))
                {
                    break;
                }
                else 
                {
                    PrintErrorMessage("Podaj poprawną opcję");
                }
            }  
        }
    }
}
