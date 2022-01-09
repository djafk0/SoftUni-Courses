using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int checker = n;

            for (int i = 0; i < n; i++)
            {
                int[] currMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currMatrix[j];
                    
                    if (i == j)
                    {
                        primaryDiagonal += currMatrix[j];
                    }
                    if (checker - 1 == j)
                    {
                        secondaryDiagonal += currMatrix[j];
                        checker--;
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
