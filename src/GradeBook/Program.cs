using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new DiskBook("Somsubhra");
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
        }

        private static void EnterGrades(IBook book)
        {
            Console.WriteLine("Enter No of grades you want top input:");
            int noOfInput = Int32.Parse(Console.ReadLine());
            for (var i = 0; i < noOfInput; i++)
            {
                var grade = double.Parse(Console.ReadLine());
                book.AddGrade(grade);
            }
            Console.WriteLine("Want to compute Result?");
            Console.WriteLine("Y/N");
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
