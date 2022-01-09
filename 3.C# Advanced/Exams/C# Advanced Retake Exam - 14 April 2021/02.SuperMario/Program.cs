using System;
using System.Linq;

namespace _02_SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lifes = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int rowLocation = 0;
            int colLocation = 0;
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        rowLocation = i;
                        colLocation = j;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                matrix[enemyRow][enemyCol] = 'B';
                matrix[rowLocation][colLocation] = '-';

                if (command[0] == "W")
                {
                    if (rowLocation - 1 >= 0)
                    {
                        rowLocation--;
                    }
                }
                else if (command[0] == "S")
                {
                    if (rowLocation + 1 < n)
                    {
                        rowLocation++;
                    }
                }
                else if (command[0] == "A")
                {
                    if (colLocation - 1 >= 0)
                    {
                        colLocation--;
                    }
                }
                else if (command[0] == "D")
                {
                    if (colLocation + 1 < n)
                    {
                        colLocation++;
                    }
                }

                lifes--;

                if (lifes <= 0)
                {
                    Console.WriteLine($"Mario died at {rowLocation};{colLocation}.");
                    matrix[rowLocation][colLocation] = 'X';
                    break;
                }

                if (matrix[rowLocation][colLocation] == 'P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lifes}");
                    matrix[rowLocation][colLocation] = '-';
                    break;
                }
                else if (matrix[rowLocation][colLocation] == 'B')
                {
                    lifes -= 2;

                    if (lifes <= 0)
                    {
                        Console.WriteLine($"Mario died at {rowLocation};{colLocation}.");
                        matrix[rowLocation][colLocation] = 'X';
                        break;
                    }
                    else
                    {
                        matrix[rowLocation][colLocation] = 'M';
                    }
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
    }
}
