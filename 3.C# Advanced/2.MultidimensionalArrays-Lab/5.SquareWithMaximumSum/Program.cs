using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demension = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[demension[0], demension[1]];
            int maxSum = int.MinValue;
            int row = 0;
            int col = 0;

            for (int i = 0; i < demension[0]; i++)
            {
                int[] curr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < demension[1]; j++)
                {
                    matrix[i, j] = curr[j];
                }
            }

            for (int i = 0; i < demension[0] - 1; i++)
            {
                for (int j = 0; j < demension[1] - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        row = i;
                        col = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[row,col]} {matrix[row,col + 1]}\n{matrix[row + 1, col]} {matrix[row + 1,col + 1]}\n{maxSum}");
        }
    }
}
