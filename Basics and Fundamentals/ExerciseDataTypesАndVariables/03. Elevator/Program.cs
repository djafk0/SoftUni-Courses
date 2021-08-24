using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            double peopleInside = double.Parse(Console.ReadLine());
            double courses = Math.Ceiling(people / peopleInside);
            Console.WriteLine(courses);

        }
    }
}
