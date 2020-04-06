using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book 
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            Name=name;
            grades=new List<double>();
        }

        public void AddGrade(double grade)
        {
            if(grade>=0 && grade<=100)
            {
                this.grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var result=new Statistics();
            result.Average=0.0;
            result.High=double.MinValue;
            result.Low=double.MaxValue;

            foreach(var number in grades)
            {
                result.Low=Math.Min(number,result.Low);
                result.High=Math.Max(number,result.High);
                result.Average+=number;
            }

            result.Average/=grades.Count;
            switch(result.Average)
            {
                case var d when d>=90.0:
                    result.Letter='A';
                    break;
                case var d when d>=80.0:
                    result.Letter='B';
                    break;
                case var d when d>=70.0:
                    result.Letter='C';
                    break;
                case var d when d>=60.0:
                    result.Letter='D';
                    break;
                default:
                    result.Letter='F';
                    break;
            }
            return result;
        }
    }
}