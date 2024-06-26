﻿using Biblioteka.Menu.Books;
using Biblioteka.Menu.Entry;
using Biblioteka.Model;
using System.Diagnostics.Metrics;

namespace Biblioteka
{
    internal class Program
    {
        //static Librarian employee = new Librarian("Dropsik", "B", 10);
        //static Librarian employee2 = new Librarian("Leonardo", "DiCaprio", 49);
        //static Librarian employee3 = new Librarian("Johny", "Deep", 60);
        //static Librarian employee4 = new Librarian("Tomasz", "Karolak", 52);

        //static Reader reader = new Reader("Roksana", "SJ", 23);
        //static Reader reader2 = new Reader("Puchacz", "S", 2);
        //static Reader reader3 = new Reader("Mariah", "Carey", 54);
        //static Reader reader4 = new Reader("John", "Travolta", 69);
        //static Reader reader5 = new Reader("Sylvester", "Stallone", 77);
        //static Reader reader6 = new Reader("Adam", "Sandler", 57);
        //static Reader reader7 = new Reader("Jennifer", "Aniston", 54);
        //static Reader reader8 = new Reader("Brad", "Pitt", 59);
        //static Reader reader9 = new Reader("Angelina", "Jolie", 48);
        //static Reader reader10 = new Reader("Robert", "De Niro", 80);

        static Book book = new Book("J.K.", "Rowling", "Harry Potter i Kamień Filozoficzny");
        static Book book2 = new Book("J.K.", "Rowling", "Harry Potter i Komnata Tajemnic");
        static Book book3 = new Book("J.K.", "Rowling", "Harry Potter i Więzień Azkabanu");
        static Book book4 = new Book("J.K.", "Rowling", "Harry Potter i Czara Ognia");
        static Book book5 = new Book("J.K.", "Rowling", "Harry Potter i Zakon Feniksa");
        static Book book6 = new Book("J.K.", "Rowling", "Harry Potter i Książe Półkrwi");
        static Book book7 = new Book("J.K.", "Rowling", "Harry Potter i Insygnia Śmierci");
        static Book book8 = new Book("William", "Shakespeare", "Romeo i Julia");
        //static Book book9 = new Book("Beata", "Pawlikowska", "Kody Podświadomości");
        //static Book book10 = new Book("Dan", "Brown","Anioły i demony");
        //static Book book11 = new Book("J.R.R.", "Tolkien","Bractwo Pierścienia. Władca Pierścieni.");
        //static Book book12 = new Book("J.R.R", "Tolkien", "Dwie Wieże. Władca Pierścieni.");
        //static Book book13 = new Book("J.R.R.", "Tolkien", "Powrót Króla. Władca Pierścieni.");
        //static Book book14 = new Book("Andrzej", "Sapkowski", "Ostatnie życzenie. Wiedźmin.");
        //static Book book15 = new Book("Andrzej", "Sapkowski", "Miecz Przeznaczenia. Wiedźmin.");
        //static Book book16 = new Book("Andrzej", "Sapkowski", "Krew Elfów. Wiedźmin");
        //static Book book17 = new Book("Andrzej", "Sapkowski","Chrzest Ognia. Wiedźmin.");
        //static Book book18 = new Book("Andrzej", "Sapkowski", "Wieża jaskółki. Wiedźmin");
        //static Book book19 = new Book("Andrzej", "Sapkowski", "Pani Jeziora. Wiedźmin");
        //static Book book20 = new Book("Andrzej", "Sapkowski", "Sezon Burz. Wiedźmin.");
        //static Book book21 = new Book("Brian", "Tracy", "Nawyki Warte Miliony");
        //static Book book22 = new Book("J.R.R.", "Tolkien","Hobbit, czyli tam i z powtorem");
        //static Book book23 = new Book("Stephenie", "Meyer","Zmierzch");
        //static Book book24 = new Book("Stephenie", "Meyer", "Księżyc w Nowiu");
        //static Book book25 = new Book("Stephenie", "Meyer", "Zaćmienie");
        //static Book book26 = new Book("Stephenie", "Meyer", "Przed Świtem");
        //static Book book27 = new Book("Sara", "Shepard", "Kłamczuchy");
        //static Book book28 = new Book("Sara", "Shepard", "Bez Skazy");
        //static Book book29 = new Book("Sara", "Shepard", "Doskonałe");
        //static Book book30 = new Book("Sara", "Shepard", "Niewiarygodne");
        static User user1 = new User("a@gmail.com", "admin",UserRole.Administrator);
        static User user2 = new User("l@gmail.com", "librarian", UserRole.Librarian);
        static User user3 = new User("r@gmail.com", "reader", UserRole.Reader);
        static void Main(string[] args)
        {
            Library library = new Library();
            EntryMenu entryMenu = new EntryMenu(library);
            //library.AddBook(book);
            //library.AddBook(book2);
            //library.AddBook(book3);
            //library.AddBook(book4);
            //library.AddBook(book5);
            //library.AddBook(book6);
            //library.AddBook(book7);
            //library.AddBook(book8);

            //library.AddReader(reader);
            //library.AddReader(reader2);
            //library.AddReader(reader3);
            //library.AddReader(reader4);
            //library.AddReader(reader5);
            //library.AddReader(reader6);

            //library.AddEmployee(employee);
            //library.AddEmployee(employee2);
            //library.AddEmployee(employee3);
            //library.AddEmployee(employee4);
            library.GetUserRepository().Add(user1);
            library.GetUserRepository().Add(user2);
            library.GetUserRepository().Add(user3);
            //LibraryMenu libraryMenu = new LibraryMenu(library);
            //libraryMenu.PrintMenu();
            entryMenu.PrintMenu();
        }
    }
}