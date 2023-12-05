using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    internal class Returning
    {
        DateOnly returningDate { get; set; }
        Book book { get; set; }
        Reader reader { get; set; }

        public Returning(DateOnly returningDate, Book book, Reader reader)
        {
            this.returningDate = returningDate;
            this.book = book;
            this.reader = reader;
        }
        public override string ToString()
        {
            return "Oddanie: data oddania: " + returningDate + ", dane czytelnika: " + reader + ", książka: " + book;
        }
    }
}
