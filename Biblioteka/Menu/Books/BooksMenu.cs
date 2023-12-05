using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Books
{
    internal class BooksMenu
    {
        Library library;
        AddBookMenu addBookMenu;
        SearchByTitleMenu searchByTitleMenu;
        SearchByAuthorMenu searchByAuthorMenu;
        RemoveBookMenu removeBookMenu;
        public BooksMenu(Library library)
        {
            this.library = library;
            addBookMenu = new AddBookMenu(library);
            searchByTitleMenu = new SearchByTitleMenu(library);
            searchByAuthorMenu = new SearchByAuthorMenu(library);
            removeBookMenu = new RemoveBookMenu(library);
        }

        public void printBooksMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Dodaj ksiażkę");
                Console.WriteLine("2.Usuń książkę");
                Console.WriteLine("3.Wyszukaj książkę");
                Console.WriteLine("4.Wypisz wszystkie książki");
                Console.WriteLine("5.Wróć");
                Console.WriteLine("Wpisz opcje: ");
                bool isItTrue = true;
                do
                {
                    try
                    {
                        int option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            addBookMenu.addBookMenu();
                        }
                        else if (option == 2)
                        {
                            removeBookMenu.removeBookMenu();
                        }
                        else if (option == 3)
                        {
                            Console.WriteLine("1.Wyszukaj po autorze");
                            Console.WriteLine("2.Wyszukacj po tytule");
                            Console.WriteLine("Podaj opcję: ");
                            bool isItReallyTrue = true;
                            do
                            {
                                try
                                {
                                    int choose = int.Parse(Console.ReadLine());
                                    switch (choose)
                                    {
                                        case 1:
                                            searchByAuthorMenu.searchByAuthorMenu();
                                            break;
                                        case 2:
                                            searchByTitleMenu.searchByTitleMenu();
                                            break;
                                        default:
                                            Console.WriteLine("Podaj poprawną opcję!");
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Aby wybrać opcję musisz podać wartość liczbową 1 lub 2!");
                                    isItReallyTrue = false;
                                }
                            } while (isItReallyTrue == false);
                        }
                        else if (option == 4)
                        {
                            Console.WriteLine("Lista książek:");
                            library.listTheBooks();
                        }
                        else if (option == 5)
                        {
                            break;                        }
                        else
                        {
                            Console.WriteLine("Niepoprawna wartość");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Aby wybrać opcję musisz podać wartość liczbową od 1 - 5!");
                        isItTrue = false;
                    }
                    
                } while (isItTrue == false);
            }
        }
    }
}
