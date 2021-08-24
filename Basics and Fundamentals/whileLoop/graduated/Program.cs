using System;

namespace graduated
{
    class Program
    {
        static void Main(string[] args)
        {
            double notPassed = 0;
            double klas = 0;
            string name = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            while (klas <= 12)
            {
                grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    notPassed += 1;
                }
                if (notPassed > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {klas} grade");
                    break;
                }
                klas += 1;
            }
            double fin = grade / klas;
            Console.WriteLine($"{name} graduated.Average grade: {fin:f2}");

        }
    }
}
