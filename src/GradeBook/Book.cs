
using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book:IBook
    {
        public List<double> grades;
        public string Name { get; set; }
        public Book(string name)
        {
            Name=name;
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public class DiskBook:Book
    {
        public DiskBook(string name):base(name)
        {
            grades=new List<double>();
        }

        public override void AddGrade(double grade)
        {
            using(var writer=File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var result=new Statistics();
            using(var reader=File.OpenText($"{Name}.txt"))
            {
                var line=reader.ReadLine();
                while(line!=null)
                {
                    var number=double.Parse(line);
                    result.Add(number);
                    line=reader.ReadLine();
                }
            }

            return result;
        }

        public override event GradeAddedDelegate GradeAdded; 
    }
    public class InMemoryBook:Book
    {
        public InMemoryBook(string name):base(name)
        {
            //Name=name;
            grades=new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if(grade>=0 && grade<=100)
            {
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }
        public override event GradeAddedDelegate GradeAdded;

        public void AddGrade(char letter)
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

        public override Statistics GetStatistics()
        {
            var result=new Statistics();

            foreach(var number in grades)
            {
                result.Add(number);
            }
            
            return result;
        }
    }
}