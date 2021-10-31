using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimension[0];
            int col = dimension[1];
            string[,] matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                string[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = curr[j];
                }
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "swap" && command.Length == 5)
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (row1 < 0 || row1 >= row || col1 < 0 || col1 >= col || row2 < 0 || row2 >= row || col2 < 0 || col2 >= col)
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        string firstValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstValue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i,j] + " ");
                    }

                    Console.WriteLine();
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
