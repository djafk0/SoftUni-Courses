using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demension = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[demension[0], demension[1]];

            for (int row = 0; row < demension[0]; row++)
            {
                int[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < demension[1]; col++)
                {
                    matrix[row, col] = curr[col];
                }
            }


            for (int col = 0; col < demension[1]; col++)
            {
                int sum = 0;

                for (int row = 0; row < demension[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

        }
    }
}
