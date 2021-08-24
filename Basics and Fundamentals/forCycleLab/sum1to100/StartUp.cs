using System;

namespace sum1to100
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                int n = int.Parse(Console.ReadLine());
                sum += n; 
            }
            Console.WriteLine(sum);

        }
    }
}
