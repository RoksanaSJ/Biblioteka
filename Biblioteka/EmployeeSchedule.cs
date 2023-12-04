using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class EmployeeSchedule : Employee
    {
        DateOnly workingDay = new DateOnly();
        DateOnly freeDay = new DateOnly();
        public EmployeeSchedule (DateOnly workingDay, DateOnly freeDay, String name, String surname, int age, int ID) : base(name,surname,age,ID)
        {
            this.workingDay = workingDay;
            this.freeDay = freeDay;
        }


        //public static void choosingWorkingDays()
        //{
        //    Random rndm = new Random();

        //    List<int> possible = Enumerable.Range(1, 31).ToList();
        //    List<int> listNumbers1 = new List<int>();
        //    List<int> listNumbers2 = new List<int>();
        //    List<int> listNumbers3 = new List<int>();
        //    List<int> listNumbers4 = new List<int>();
        //    List<int> listNumbers5 = new List<int>();

        //    for (int i = 1; i < 32; i++)
        //    {
        //        int index = rndm.Next(1, possible.Count);
        //        if (i <= 6)
        //        {

        //            listNumbers1.Add(possible[index]);
        //            possible.RemoveAt(index);
        //        }
        //        else if (i > 6 && i <= 12)
        //        {
        //            listNumbers2.Add(possible[index]);
        //            possible.RemoveAt(index);
        //        }
        //        else if (i > 12 && i <= 18)
        //        {
        //            listNumbers3.Add(possible[index]);
        //            possible.RemoveAt(index);
        //        }
        //        else if (i > 18 && i <= 24)
        //        {
        //            listNumbers4.Add(possible[index]);
        //            possible.RemoveAt(index);
        //        }
        //        else if (i > 24 && i <= 31)
        //        {
        //            listNumbers5.Add(possible[index]);
        //            possible.RemoveAt(index);
        //        }
        //    }
        //    Console.WriteLine("Lista pierwsza");
        //    foreach (var item in listNumbers1)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("Lista druga");
        //    foreach (var item in listNumbers2)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("Lista trzecia");
        //    foreach (var item in listNumbers3)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("Lista czwarta");
        //    foreach (var item in listNumbers4)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("Lista piąta");
        //    foreach (var item in listNumbers5)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
