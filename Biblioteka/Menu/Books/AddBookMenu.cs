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
        public void addBookMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj tytuł");
                string title = Console.ReadLine();
                Console.WriteLine("Podaj imię autora");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko autora");
                string surname = Console.ReadLine();
                Console.WriteLine($"Czy książka, którą chcesz dodać ma następujące parametry: Tytuł {title}, Autor {name} {surname}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                char userOption = char.Parse(Console.ReadLine());
                if (userOption == 'y')
                {
                    Book book = new Book(name, surname, title);
                    library.addBook(book);
                    Console.WriteLine($"Gratulację! Udało ci się dodać książkę: Tytuł {title}, Autor {name} {surname}");
                    break;
                }
                else if (userOption == 'n')
                {
                    addBookMenu();
                } else if(userOption == 'b')
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
