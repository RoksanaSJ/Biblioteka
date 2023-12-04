using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Borrowing 
    {
        DateOnly borrowingDate {  get; set; }
        Book book { get; set; }
        Reader reader { get; set; }
        public Borrowing(DateOnly date, Book book, Reader reader)
        {
            this.borrowingDate = date;
            this.reader = reader;
            this.book = book;
        }
        public override string ToString()
        {
            return "Wypożyczenie: data wypożyczenia: " + borrowingDate + ", czytelnik: " + reader + ",książka: " + book;
        }

    }
}
