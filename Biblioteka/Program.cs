using Biblioteka.Menu.Books;
using Biblioteka.Model;
using System.Diagnostics.Metrics;

namespace Biblioteka
{
    internal class Program
    {
        static Employee employee = new Employee("Dropsik", "B", 10, 1);
        static Employee employee2 = new Employee("Leonardo", "DiCaprio", 49, 3);
        static Employee employee3 = new Employee("Johny", "Deep", 60, 4);
        static Employee employee4 = new Employee("Tomasz", "Karolak", 52, 5);

        static Reader reader = new Reader("Roksana", "SJ", 23);
        static Reader reader2 = new Reader("Puchacz", "S", 2);
        static Reader reader3 = new Reader("Mariah", "Carey", 54);
        static Reader reader4 = new Reader("John", "Travolta", 69);
        static Reader reader5 = new Reader("Sylvester", "Stallone", 77);
        static Reader reader6 = new Reader("Adam", "Sandler", 57);
        static Reader reader7 = new Reader("Jennifer", "Aniston", 54);
        static Reader reader8 = new Reader("Brad", "Pitt", 59);
        static Reader reader9 = new Reader("Angelina", "Jolie", 48);
        static Reader reader10 = new Reader("Robert", "De Niro", 80);

        static Book book = new Book("J.K", "Rowling", "Harry Potter i Kamień Filozoficzny");
        static Book book2 = new Book("J.K", "Rowling", "Harry Potter i Komnata Tajemnic");
        static Book book3 = new Book("J.K", "Rowling", "Harry Potter i Więzień Azkabanu");
        static Book book4 = new Book("J.K", "Rowling", "Harry Potter i Czara Ognia");
        static Book book5 = new Book("J.K", "Rowling", "Harry Potter i Zakon Feniksa");
        static Book book6 = new Book("J.K", "Rowling", "Harry Potter i Książe Półkrwi");
        static Book book7 = new Book("J.K", "Rowling", "Harry Potter i Insygnia Śmierci");
        static Book book8 = new Book("William", "Shakespeare", "Romeo i Julia");
        static Book book9 = new Book("Beata", "Pawlikowska", "Kody Podświadomości");
        static Book book10 = new Book("Dan", "Brown","Anioły i demony");
        static Book book11 = new Book("J.R.R.", "Tolkien","Bractwo Pierścienia. Władca Pierścieni.");
        static Book book12 = new Book("J.R.R", "Tolkien", "Dwie Wieże. Władca Pierścieni.");
        static Book book13 = new Book("J.R.R.", "Tolkien", "Powrót Króla. Władca Pierścieni.");
        static Book book14 = new Book("Andrzej", "Sapkowski", "Ostatnie życzenie. Wiedźmin.");
        static Book book15 = new Book("Andrzej", "Sapkowski", "Miecz Przeznaczenia. Wiedźmin.");
        static Book book16 = new Book("Andrzej", "Sapkowski", "Krew Elfów. Wiedźmin");
        static Book book17 = new Book("Andrzej", "Sapkowski","Chrzest Ognia. Wiedźmin.");
        static Book book18 = new Book("Andrzej", "Sapkowski", "Wieża jaskółki. Wiedźmin");
        static Book book19 = new Book("Andrzej", "Sapkowski", "Pani Jeziora. Wiedźmin");
        static Book book20 = new Book("Andrzej", "Sapkowski", "Sezon Burz. Wiedźmin.");
        static Book book21 = new Book("Brian", "Tracy", "Nawyki Warte Miliony");
        static Book book22 = new Book("J.R.R.", "Tolkien","Hobbit, czyli tam i z powtorem");
        static Book book23 = new Book("Stephenie", "Meyer","Zmierzch");
        static Book book24 = new Book("Stephenie", "Meyer", "Księżyc w Nowiu");
        static Book book25 = new Book("Stephenie", "Meyer", "Zaćmienie");
        static Book book26 = new Book("Stephenie", "Meyer", "Przed Świtem");
        static Book book27 = new Book("Sara", "Shepard", "Kłamczuchy");
        static Book book28 = new Book("Sara", "Shepard", "Bez Skazy");
        static Book book29 = new Book("Sara", "Shepard", "Doskonałe");
        static Book book30 = new Book("Sara", "Shepard", "Niewiarygodne");
        static void Main(string[] args)
        {
            Library library = new Library();

            library.addBook(book);
            library.addBook(book2);
            library.addBook(book3);
            library.addBook(book4);
            library.addBook(book5);
            library.addBook(book6);
            library.addBook(book17);
            library.addBook(book22);

            library.addReader(reader);
            library.addReader(reader2);
            library.addReader(reader3);
            library.addReader(reader4);
            library.addReader(reader5);
            library.addReader(reader6);

            LibraryMenu libraryMenu = new LibraryMenu(library);
            libraryMenu.printLibraryMenu();

            //    initializeLibrary(library);
            //    Console.WriteLine("Lista książek przed pierwszym wypożyczeniem");
            //    library.listTheBooks();

            //    library.borrowBook(book, reader2);
            //    library.borrowBook(book26, reader7);
            //    library.borrowBook(book13, reader);
            //    library.borrowBook(book4, reader4);
            //    library.borrowBook(book18, reader4);
            //    library.borrowBook(book2, reader8);
            //    library.borrowBook(book6, reader9);
            //    library.borrowBook(book19, reader3);
            //    library.borrowBook(book20, reader10);
            //    library.returnBook(book19, reader3);
            //    library.returnBook(book26, reader7);
            //    library.returnBook(book13, reader);
            //    library.returnBook(book4, reader4);

            //    //Lista książek po wypożyczeniach
            //    Console.WriteLine(" ");
            //    Console.WriteLine("Lista książek po wypożyczeniach");
            //    library.listTheBooks();

            //    Console.WriteLine("Lista wypożyczeń");
            //    library.listTheBorrowings();

            //    Console.WriteLine("Lista zwrotów/oddanych książek");
            //    library.listTheReturnings();



        }

        public static void initializeLibrary(Library b)
        {
            b.addBook(book);
            b.addBook(book2);
            b.addBook(book3);
            b.addBook(book4);
            b.addBook(book5);
            b.addBook(book6);
            b.addBook(book7);
            b.addBook(book8);
            b.addBook(book9);
            b.addBook(book10);
            b.addBook(book11);
            b.addBook(book12);
            b.addBook(book13);
            b.addBook(book14);
            b.addBook(book15);
            b.addBook(book16);
            b.addBook(book17);
            b.addBook(book18);
            b.addBook(book19);
            b.addBook(book20);
            b.addBook(book21);
            b.addBook(book22);
            b.addBook(book23);
            b.addBook(book24);
            b.addBook(book25);
            b.addBook(book26);
            b.addBook(book27);
            b.addBook(book28);
            b.addBook(book29);
            b.addBook(book30);

            b.addReader(reader);
            b.addReader(reader2);
            b.addReader(reader3);
            b.addReader(reader4);
            b.addReader(reader5);
            b.addReader(reader6);
            b.addReader(reader7);
            b.addReader(reader8);
            b.addReader(reader9);
            b.addReader(reader10);

            b.addEmployee(employee);
            b.addEmployee(employee2);
            b.addEmployee(employee2);
            b.addEmployee(employee3);
            b.addEmployee(employee4);

        }
    }
}