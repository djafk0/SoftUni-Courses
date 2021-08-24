using System;

namespace _4._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                TriangleMethod(i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                TriangleMethod(i);
            }
        }

        private static void TriangleMethod(int i)
        {
            for (int j = 1; j < i + 1; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
