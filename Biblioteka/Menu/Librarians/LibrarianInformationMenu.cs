﻿using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Menu.Librarians
{
    internal class LibrarianInformationMenu : Menu
    {
        LibrarianInformationMenu(Library library) : base(library)
        {

        }
        public override void PrintMenu()
        {
            //while (true)
            //{
            //    List<Librarian> librarians = Library.GetLibrarians();
            //    User currentUser = Library.GetCurrentUser();
            //    List<User> userInfo = Library.GetUsers();
            //    List<Borrowing> borrowings = new List<Borrowing>();
            //    borrowings = Library.GetBorrowings();
            //    List<Returning> readerReturnings = new List<Returning>();
            //    readerReturnings = Library.GetReturnings();
            //    Log.PrintInformationMessage("Dane użytkownika: ");
            //    foreach (Librarian librarian in librarians)
            //    {
            //        if (librarian.GetUser().Equals(currentUser))
            //        {
            //            Console.WriteLine(librarian);
            //        }
            //    }
            //    Console.WriteLine("");
            //    foreach (User user in userInfo)
            //    {
            //        if (user.Equals(currentUser))
            //        {
            //            Console.WriteLine(user);
            //        }
            //    }
            //    break;
            //}
        }
    }
}
