﻿using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class SearchByID : Menu
    {
        public SearchByID(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Podaj ID książki: ");
                int booksID = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine($"Czy ID, po którym chcesz wyszukać książkę ma następujące ID: {booksID}?");
                Console.WriteLine("Jeżeli tak wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić wpisz 'b'");
                string userOption = Console.ReadLine();
                Console.WriteLine("");
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = Library.GetAllBooks();
                    bool isAvailable = false;
                    foreach (var book in allBooks)
                    {
                        if (book.GetID() == booksID)
                        {
                            PrintSuccessMessage($"Gratulację! Udało ci się wyszukać książkę o ID {booksID}");
                            Console.WriteLine(book);
                            Console.WriteLine("");
                            isAvailable = true;
                        }
                    }
                    if (isAvailable == false)
                    {
                        PrintErrorMessage("Niestety nie ma książki o takim ID.");
                    }
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
                    PrintErrorMessage("Podaj poprawną opcję!");
                }
            }
        }
    }
}
