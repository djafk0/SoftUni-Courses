using System;

namespace _01.__SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int pause = 0;
            int questions = int.Parse(Console.ReadLine());
            double hours = Math.Ceiling((double)questions / (first + second + third));

            for (int i = 1; i < hours; i++)
            {
                if (i % 3 == 0)
                {
                    pause++;
                }
            }
            Console.WriteLine($"Time needed: {hours + pause}h.");
        }
    }
}
