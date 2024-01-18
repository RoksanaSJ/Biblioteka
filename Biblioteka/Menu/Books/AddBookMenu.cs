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
                timeSpan = returningDate - borrowingDate;
                Console.WriteLine("\nPodaj tytuł książki: ");
                string title = Console.ReadLine();
                Console.WriteLine("\nPodaj imię autora: ");
                string name = Console.ReadLine();
                Console.WriteLine("\nPodaj nazwisko autora: ");
                string surname = Console.ReadLine();
                Console.WriteLine("\nPodaj kategorie ksiażki (po przecinku)");
                string category = Console.ReadLine();
                Console.WriteLine($"\nCzy książka, którą chcesz dodać ma następujące parametry: Tytuł: {title}, Autor: {name} {surname}, Kategoria: {category}?");
                Console.WriteLine("\nJeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do menu książki wpisz 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    HashSet<String> bookCategories = new HashSet<String>();
                    string[] splitedCategories = category.Split(',');
                    foreach(string categories in splitedCategories)
                    {
                        bookCategories.Add(categories.ToLower());
                    }
                    Book book = new Book(name, surname, title, bookCategories);
                    Library.AddBook(book);
                    Log.PrintSuccessMessage(($"Gratulację! Udało ci się dodać książkę: Tytuł: {title}, Autor: {name} {surname}, Kategoria: {category}"));
                    break;
                }
                else if (userOption.Equals("n"))
                {
                    continue;
                } else if (userOption.Equals("b"))
                {
                    break;
                }
                else 
                {
                    Log.PrintErrorMessage("Podaj poprawną opcję");
                }
            }  
        }
    }
}
