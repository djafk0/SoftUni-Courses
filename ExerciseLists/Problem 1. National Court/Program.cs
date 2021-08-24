
using System;

namespace Problem_1._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstAnswersPerHour = int.Parse(Console.ReadLine());
            int secondAnswersPerHour = int.Parse(Console.ReadLine());
            int thirdAnswersPerHour = int.Parse(Console.ReadLine());
            int totalPeopleCount = int.Parse(Console.ReadLine());

            int sum = firstAnswersPerHour + secondAnswersPerHour + thirdAnswersPerHour;
            int rest = 0;
            for (int i = 1; i < totalPeopleCount ; i++)
            {
                if (sum < totalPeopleCount)
                {
                    sum += firstAnswersPerHour + secondAnswersPerHour + thirdAnswersPerHour;
                }
                else
                {
                    Console.WriteLine($"Time needed: {i + rest}h.");
                    break;
                }
                if (i % 3 == 0)
                {
                    rest++;
                }
            }
            if (totalPeopleCount==0)
            {
                Console.WriteLine($"Time needed: {rest}h.");
            }
        }
    }
}
