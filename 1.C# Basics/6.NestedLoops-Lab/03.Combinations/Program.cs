using System;

namespace _03.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combo = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        int combinations = i + j + k;
                        if (combinations == n)
                        {
                            combo++;
                        }
                    }
                }
            }

            Console.WriteLine(combo);
        }
    }
}
