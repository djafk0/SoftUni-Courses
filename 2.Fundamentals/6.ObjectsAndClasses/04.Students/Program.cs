using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Average_Grades
{
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }
        public Student(string firstName, string secondName, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }
        public double getGrade()
        {
            return this.Grade;
        }

        public override string ToString()
        {
            return string.Format(this.FirstName, this.SecondName, this.Grade);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ");
                string firstName = info[0];
                string secondName = info[1];
                double grade = double.Parse(info[2]);

                Student student = new Student(firstName, secondName, grade);
                students.Add(student);

                //Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:f2}");

            }
            students.OrderByDescending(t => t.Grade).ThenBy(t => t.FirstName).ToList();
            List<Student> sortedStudents = students.OrderByDescending(t => t.Grade).ThenBy(t => t.FirstName).ThenBy(t => t.SecondName).ToList();

            foreach (Student t in sortedStudents)
            {
                Console.WriteLine($"{t.FirstName} {t.SecondName}: {t.Grade:f2}");
            }

        }
    }
}