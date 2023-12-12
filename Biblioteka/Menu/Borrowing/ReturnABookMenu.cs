﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Model;

namespace Biblioteka.Menu.Borrowing
{
    internal class ReturnABookMenu : Menu
    {
        public ReturnABookMenu(Library library) : base(library)
        {

        }
        public override void printMenu() 
        {
            while (true)
            {
                Console.WriteLine("Podaj swój identyfikator:");
                int userID = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj ID książki");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine($"Czy parametry, które chcesz podać są następujące: twoje ID {userID}, ID książki {ID}?");
                Console.WriteLine("Jeżeli tak, wpisz 'y', jeżeli nie wpisz 'n', jeżeli chcesz wrócić do główneg menu wpisz 'b':");
                string userOption = Console.ReadLine();
                if (userOption.Equals("y"))
                {
                    List<Book> allBooks = library.getAllBooks();
                    List<Reader> readers = library.getReaders();

                    foreach (var book in allBooks)
                    {
                        if (book.getID() == ID)
                        {
                            Console.WriteLine("Książka znaleziona");
                            foreach (var reader in readers)
                            {
                                if (reader.getID() == userID)
                                {
                                    library.returnBook(book, reader);
                                    Console.WriteLine($"Gratulację {reader}, właśnie oddałeś książkę {book}");
                                }
                            }
                        }
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
