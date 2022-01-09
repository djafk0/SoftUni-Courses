using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimension[0];
            int col = dimension[1];
            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = curr[j];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < col - 2; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] 
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] 
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}\n" +
                $"{matrix[maxRow,maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}" +
                $"\n{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]} {matrix[maxRow + 1, maxCol + 2]}" +
                $"\n{matrix[maxRow + 2, maxCol]} {matrix[maxRow + 2, maxCol + 1]} {matrix[maxRow + 2, maxCol + 2]}");
        }
    }
}
