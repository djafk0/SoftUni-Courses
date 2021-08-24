using System;

namespace _03.Elevator_3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int peopleFitInside = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Math.Ceiling((double)people/peopleFitInside)}");
        }
    }
}
