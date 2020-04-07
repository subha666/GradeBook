using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Name:");
            var input = Console.ReadLine();
            var book1 = new DiskBook(input);
            book1.GradeAdded += OnGradeAdded;
            // book1.AddGrade(89.1);
            // book1.AddGrade(90.5);
            // book1.AddGrade(44);
            // book1.AddGrade(77.5);
            // var result=book1.GetStatistics();

            EnterGrades(book1);
            var result = book1.GetStatistics();
            
            Console.WriteLine($"This is {book1.Name}'s gradebook");
            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The average grade is {result.Average:N1}");
            Console.WriteLine($"The letter grade is {result.Letter}");
            Console.ReadLine();
        }

        private static void EnterGrades(IBook book)
        {
            bool result = false;
            while (result == false)
            {
                Console.WriteLine("Enter grades/Press 'C' to Compute result:");
                var input = Console.ReadLine();
                if(input.ToUpper()=="C")
                {
                    result = true;
                }
                else
                {
                    var number = double.Parse(input);
                    book.AddGrade(number);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
