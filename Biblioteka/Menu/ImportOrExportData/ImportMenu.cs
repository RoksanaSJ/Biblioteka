using Biblioteka.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ImportMenu : Menu
    {
        const string FILEPATH = "C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\";
        const string READERCSV = "reader.csv";
        const string BOOKCSV = "book.csv";
        const string BORROWINGCSV = "borrowing.csv";
        const string RETURNINGCSV = "returning.csv";
        const string LIBRARIANCSV = "librarian.csv";
        public ImportMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            Console.WriteLine("Importowane dane");

            using (ZipArchive archive = ZipFile.OpenRead(FILEPATH + "test.zip"))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(FILEPATH, entry.FullName));
                }
            }
            Console.WriteLine("Wypakowano paczkę zip");
            Library.ClearAllData();
            Console.WriteLine("Rozpoczęcie importowania danych");
            ImportBooks();
            Console.WriteLine("Zaimportowano książki");
            ImportReaders();
            Console.WriteLine("Zaimportowano czytelników");
            ImportLibrarians();
            Console.WriteLine("Zaimportowano pracowników");
            ImportBorrowing();
            Console.WriteLine("Zaimportowano wypożyczenia");
            ImportReturnings();
            Console.WriteLine("Zaimportowano zwroty książek");

            string[] files = { FILEPATH + READERCSV, FILEPATH + BOOKCSV, FILEPATH + BORROWINGCSV, FILEPATH + RETURNINGCSV, FILEPATH + LIBRARIANCSV };

            foreach (string file in files)
            {
                RemoveFile(file);
            }
        }
        public void RemoveFile(string pathFile)
        {
            bool isExist = File.Exists(pathFile);
            if (isExist == true)
            {
                File.Delete(pathFile);
            }
        }
        public Book.BookState Convert (string state)
        {
            if (state.Equals("Available"))
            {
                return Book.BookState.Available;
            } else
            {
                return Book.BookState.Booked;
            }
        }
        public void ImportBooks()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\book.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    string[] splitedBook = line.Split(',');
                    string name = splitedBook[2];
                    string surname = splitedBook[3];
                    string title = splitedBook[1];
                    int ID = int.Parse(splitedBook[0]);
                    Book.BookState bookState = Convert(splitedBook[4]);
                    Book book = new Book(name, surname, title, ID, bookState);
                    Library.AddBook(book);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        public void ImportLibrarians()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\librarian.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    string[] splitedLibrarian = line.Split(',');
                    string name = splitedLibrarian[1];
                    string surname = splitedLibrarian[2];
                    int age = int.Parse(splitedLibrarian[3]);
                    int ID = int.Parse(splitedLibrarian[0]);
                    Librarian librarian = new Librarian(name, surname, age, ID);
                    Library.AddEmployee(librarian);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        public void ImportReaders()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\reader.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    string[] splitedReader = line.Split(',');
                    string name = splitedReader[1];
                    string surname = splitedReader[2];
                    int age = int.Parse(splitedReader[3]);
                    int ID = int.Parse(splitedReader[0]);
                    Reader reader = new Reader(ID, name, surname, age);
                    Library.AddReader(reader);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        public void ImportBorrowing()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\borrowing.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    string[] splitedBookBorrowing = line.Split(',');
                    int readerID = int.Parse(splitedBookBorrowing[1]);
                    int bookID = int.Parse(splitedBookBorrowing[2]);

                    Book bookFound = Library.FindBookByID(bookID);
                    Reader readerFound = Library.FindReaderByID(readerID);
                    DateTime dateTimeFound = DateTime.ParseExact(splitedBookBorrowing[0], "dd.MM.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    Biblioteka.Model.Borrowing borrowingFound = new Biblioteka.Model.Borrowing(dateTimeFound, bookFound, readerFound);
                    Library.AddBorrowing(borrowingFound);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        public void ImportReturnings()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\returning.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                     string[] splitedBookReturning = line.Split(',');
                    int readerID = int.Parse(splitedBookReturning[1]);
                    int bookID = int.Parse(splitedBookReturning[2]);

                    Book bookFound = Library.FindBookByID(bookID);
                    Reader readerFound = Library.FindReaderByID(readerID);
                    DateTime dateTimeFound = DateTime.ParseExact(splitedBookReturning[0], "dd.MM.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    Returning returningFound = new Returning(dateTimeFound, bookFound, readerFound);
                    Library.ReturnBook(bookFound, readerFound);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
