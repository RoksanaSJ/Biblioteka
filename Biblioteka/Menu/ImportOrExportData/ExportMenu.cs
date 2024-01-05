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
        const string CHARGEINFORMATIONCSV = "chargeinformation.csv";
        public ExportMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            Console.WriteLine("Eksportowane dane");

            try
            {
                string[] files = { FILEPATH + READERCSV, FILEPATH + BOOKCSV, FILEPATH + BORROWINGCSV, FILEPATH + RETURNINGCSV, FILEPATH + LIBRARIANCSV, FILEPATH + CHARGEINFORMATIONCSV}; 
                Console.WriteLine("Podaj nazwę pliku zip:");
                string zipFile = Console.ReadLine();
                if (!zipFile.EndsWith(".zip"))
                {
                    zipFile = zipFile + ".zip";
                }
                SaveToFile(READERCSV,Library.GetReaders());
                SaveToFile(BOOKCSV, Library.GetAllBooks());
                SaveToFile(BORROWINGCSV, Library.GetBorrowings());
                SaveToFile(RETURNINGCSV, Library.GetReturnings());
                SaveToFile(LIBRARIANCSV, Library.GetLibrarians());
                SaveToFile(CHARGEINFORMATIONCSV, Library.GetChargeInformation());

                using (ZipArchive zip = ZipFile.Open(FILEPATH + zipFile, ZipArchiveMode.Update))
                {
                    zip.CreateEntryFromFile(FILEPATH + READERCSV, READERCSV);
                    zip.CreateEntryFromFile(FILEPATH + BOOKCSV, BOOKCSV);
                    zip.CreateEntryFromFile(FILEPATH + BORROWINGCSV, BORROWINGCSV);
                    zip.CreateEntryFromFile(FILEPATH + RETURNINGCSV, RETURNINGCSV);
                    zip.CreateEntryFromFile(FILEPATH + LIBRARIANCSV, LIBRARIANCSV);
                    zip.CreateEntryFromFile(FILEPATH + CHARGEINFORMATIONCSV, CHARGEINFORMATIONCSV);
                }
                foreach (string file in files)
                {
                    RemoveFile(file);
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
        public void SaveToFile<T>(string fileName, List<T> records) where T : Record
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(FILEPATH + fileName);
            //Write a line of text
            foreach (Record record in records)
            {
                sw.WriteLine(record.ToCSV());
            }
            //Close the file
            sw.Close();

            Log.PrintInformationMessage("Pełna ścieżka pliku:");
            Log.PrintInformationMessage(FILEPATH + fileName);
        }
        public void RemoveFile(string pathFile)
        {
           bool isExist = File.Exists(pathFile);
            if(isExist == true)
            {
                File.Delete(pathFile);
            }
        }
    }
}
