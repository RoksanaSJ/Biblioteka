using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.ImportOrExportData
{
    internal class ExportMenu : Menu
    {
        const string FILEPATH = "C:\\Users\\roxys\\source\\repos\\Biblioteka\\Biblioteka\\bin\\Debug\\net6.0\\";
        const string READERCSV = "reader.csv";
        const string BOOKCSV = "book.csv";
        const string BORROWINGCSV = "borrowing.csv";
        const string RETURNINGCSV = "returning.csv";
        const string LIBRARIANCSV = "librarian.csv";
        public ExportMenu(Library library) : base(library)
        {

        }
        public override void printMenu()
        {
            Console.WriteLine("Eksportowane dane");

            try
            {
                Console.WriteLine("Podaj nazwę pliku zip:");
                string zipFile = Console.ReadLine();
                saveToFile(READERCSV,library.getReaders());
                saveToFile(BOOKCSV, library.getAllBooks());
                saveToFile(BORROWINGCSV, library.getBorrowings());
                saveToFile(RETURNINGCSV, library.getReturnings());
                saveToFile(LIBRARIANCSV, library.getLiblarians());

                using (ZipArchive zip = ZipFile.Open(FILEPATH + zipFile, ZipArchiveMode.Update))
                {
                    zip.CreateEntryFromFile(FILEPATH + READERCSV, READERCSV);
                    zip.CreateEntryFromFile(FILEPATH + BOOKCSV, BOOKCSV);
                    zip.CreateEntryFromFile(FILEPATH + BORROWINGCSV, BORROWINGCSV);
                    zip.CreateEntryFromFile(FILEPATH + RETURNINGCSV, RETURNINGCSV);
                    zip.CreateEntryFromFile(FILEPATH + LIBRARIANCSV, LIBRARIANCSV);
                }
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
        public void saveToFile<T>(string fileName, List<T> records) where T : Record
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(FILEPATH + fileName);
            //Write a line of text
            foreach (Record record in records)
            {
                sw.WriteLine(record.toCSV());
            }
            //Close the file
            sw.Close();

            Console.WriteLine("Pełna ścieżka pliku:");
            Console.WriteLine(FILEPATH + fileName);
        }
    }
}
