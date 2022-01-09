using System;

namespace _07.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int g1 = 0;
            int g2 = 0;
            int g3 = 0;
            int g4 = 0;
            int g5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int climbersCount = int.Parse(Console.ReadLine());

                if (climbersCount < 6)
                {
                    g1 += climbersCount;
                }

                else if (climbersCount < 13)
                {
                    g2 += climbersCount;
                }

                else if (climbersCount < 26)
                {
                    g3 += climbersCount;
                }

                else if (climbersCount < 41)
                {
                    g4 += climbersCount;
                }

                else
                {
                    g5 += climbersCount;
                }
            }

            int totalCount = g1 + g2 + g3 + g4 + g5;

            Console.WriteLine($"{1.0 * g1 / totalCount * 100:f2}%");
            Console.WriteLine($"{1.0 * g2 / totalCount * 100:f2}%");
            Console.WriteLine($"{1.0 * g3 / totalCount * 100:f2}%");
            Console.WriteLine($"{1.0 * g4 / totalCount * 100:f2}%");
            Console.WriteLine($"{1.0 * g5 / totalCount * 100:f2}%");
        }
    }
}
