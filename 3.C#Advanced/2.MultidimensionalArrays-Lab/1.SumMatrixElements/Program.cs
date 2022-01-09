using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demension = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[demension[0],demension[1]];
            int sum = 0;

            for (int row = 0; row < demension[0]; row++)
            {
                int[] arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cow = 0; cow < demension[1]; cow++)
                {
                    matrix[row, cow] = arr[cow];
                    sum += arr[cow];
                }
            }
            Console.WriteLine($"{demension[0]}\n{demension[1]}\n{sum}");
        }
    }
}
