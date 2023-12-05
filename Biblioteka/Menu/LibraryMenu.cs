using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Menu.Books;
using Biblioteka.Menu.Borrowing;
using Biblioteka.Menu.Readers;

namespace Biblioteka.Menu.Books
{
    internal class LibraryMenu
    {
        BooksMenu BooksMenu;
        Library library;
        ReaderMenu readerMenu;
        BorrowingBookMenu borrowingBookMenu;
        public LibraryMenu(Library library)
        {
            BooksMenu = new BooksMenu(library);
            readerMenu = new ReaderMenu(library);
            borrowingBookMenu = new BorrowingBookMenu(library);
            this.library = library;
        }
        public void printLibraryMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Menu książek");
                Console.WriteLine("2.Menu czytelników");
                Console.WriteLine("3.Menu wypożyczenia");
                Console.WriteLine("4.Zakończ");
                Console.WriteLine("Wpisz opcje: ");
                bool isItTrue = true;
                do
                {
                    try
                    {
                        int option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            BooksMenu.printBooksMenu();
                        }
                        else if (option == 2)
                        {
                            readerMenu.printReaderMenu();
                        }
                        else if (option == 3)
                        {
                            borrowingBookMenu.printBorrowingBookMenu();
                        }
                        else if (option == 4)
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawna wartość");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Aby wybrać opcję musisz podać wartość liczbową od 1 - 4!");
                        isItTrue = false;

                    }
                } while (isItTrue == false);
                }
            }
        }
    }

