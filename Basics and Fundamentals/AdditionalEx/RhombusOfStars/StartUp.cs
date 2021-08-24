using System;

namespace RhombusOfStars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "*";
            string interval = " ";
            string b = " *";

            for (int row = 1; row <= n; row++)
            {
                for (int i = 1; i <= n - row; i++)
                {
                    Console.Write(interval);
                }
                Console.Write(a);
                for (int i = 1; i <= row - 1; i++)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
            for (int row = 1; row <= n - 1; row++)
            {
                for (int i = 1; i <= row - 1; i++)
                {
                    Console.Write(interval);
                }
                for (int i = 1; i <= n - row; i++)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
        }
    }
}
