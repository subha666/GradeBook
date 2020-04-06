using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1=new Book("Somsubhra");
            // book1.AddGrade(89.1);
            // book1.AddGrade(90.5);
            // book1.AddGrade(44);
            // book1.AddGrade(77.5);
            // var result=book1.GetStatistics();

            Console.WriteLine("Enter No of grades you want top input:");
            int noOfInput=Int32.Parse(Console.ReadLine());
            for(var i=0;i<noOfInput;i++)
            {
                var grade=double.Parse(Console.ReadLine());
                book1.AddGrade(grade);
            }
            Console.WriteLine("Want to compute Result?");
            Console.WriteLine("Y/N");
            var result=book1.GetStatistics();

            Console.WriteLine($"This is {book1.Name}'s gradebook");
            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The average grade is {result.Average:N1}");
            Console.WriteLine($"The letter grade is {result.Letter}");
        }
    }
}
