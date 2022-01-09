using System;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            for (row = 0; row < n; row++)
            {
                string chars = Console.ReadLine();

                for (col = 0; col < n; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            char a = Console.ReadLine()[0];

            for (row = 0; row < n; row++)
            {
                for (col = 0; col < n; col++)
                {
                    if (a == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{a} does not occur in the matrix");
        }
    }
}
