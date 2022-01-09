using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            int counter = 0;
            string last = input;
            int checker = 0;
            bool flag = false;

            while (input != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    checker++;
                    if (checker == n)
                    {
                        flag = true;
                        break;
                    }
                }

                sum += grade;
                counter++;
                last = input;

                input = Console.ReadLine();
            }

            if (flag)
            {
                Console.WriteLine($"You need a break, {n} poor grades.");
            }
            else
            {
                double average = (double)sum / counter;
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {last}");
            }
        }
    }
}
