using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            double result = 0;
            double something = 0;
            double value = 0;
            string presentation = "";
            int i = 0;
            int j = 0;

            for (i = 1; i <= int.MaxValue; i++)
            {
                result = 0;
                presentation = Console.ReadLine();

                if (presentation == "Finish")
                {
                    break;
                }

                for (j = 1; j <= jury; j++)
                {
                    value = double.Parse(Console.ReadLine());
                    result += value;
                }

                double finalResult = result / jury;
                Console.WriteLine($"{presentation} - {finalResult:f2}.");
                something += finalResult;
            }

            double totalResult = something / (i - 1);
            Console.WriteLine($"Student's final assessment is {totalResult:f2}.");
        }
    }
}
