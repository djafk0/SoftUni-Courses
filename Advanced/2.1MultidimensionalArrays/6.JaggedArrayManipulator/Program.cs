using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[i] = curr;

                if (i != 0)
                {
                    if (jagged[i].Length == jagged[i - 1].Length)
                    {
                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] = jagged[i][j] * 2;
                            jagged[i - 1][j] = jagged[i - 1][j] * 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < jagged[i - 1].Length; j++)
                        {
                            jagged[i - 1][j] = jagged[i - 1][j] / 2;
                        }

                        for (int j = 0; j < jagged[i].Length; j++)
                        {
                            jagged[i][j] = jagged[i][j] / 2;
                        }
                    }
                }
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (!(row < 0 || row >= n || col < 0 || col >= jagged[row].Length))
                {
                    if (command[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
    }
}
