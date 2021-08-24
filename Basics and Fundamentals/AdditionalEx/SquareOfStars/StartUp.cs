using System;

namespace SquareOfStars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "*";
            for (int i = 1 ; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write($"{a} ");
                }
                Console.WriteLine();
            }
        }
    }
}
