﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Books
{
    internal class SearchByAuthorMenu : Menu
    {
        public SearchByAuthorMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię autora: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaje nazwisko autora: ");
                string surname = Console.ReadLine();
                string authorData = name + " " + surname;
                Console.WriteLine("");
                Console.WriteLine($"Czy autor, po którym chcesz wyszukać książkę ma następujące dane: {authorData}?");
                Console.WriteLine("");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                Console.WriteLine("");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = Library.GetAllBooks();
                    bool isAvailable = false;
                    foreach (var book in allBooks)
                    {
                        if (book.GetAuthor().GetNameAndSurname().Contains(authorData))
                        {
                            Console.WriteLine(book);
                            isAvailable = true;
                        }
                    }
                    if (isAvailable == false)
                    {
                        Log.PrintErrorMessage("Niestety nie ma książki napisanej przez takiego autora.");
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
