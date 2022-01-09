using System;
using System.Collections.Generic;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int row = 0;
            int col = 0;
            int money = 0;

            List<int[]> pillarLocation = new List<int[]>();
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];

                    if (matrix[i, j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                    else if (matrix[i, j] == 'O')
                    {
                        pillarLocation.Add(new int[2] { i, j });
                    }
                }
            }

            bool flag = true;

            while (money < 50)
            {
                string command = Console.ReadLine();
                matrix[row, col] = '-';

                if (command == "up" && row - 1 >= 0)
                {
                    row--;
                }
                else if (command == "down" && row + 1 < n)
                {
                    row++;
                }
                else if (command == "left" && col - 1 >= 0)
                {
                    col--;
                }
                else if (command == "right" && col + 1 < n)
                {
                    col++;
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    flag = false;
                    break;
                }

                if (char.IsDigit(matrix[row, col]))
                {
                    money += int.Parse(matrix[row, col].ToString());
                }
                else if (matrix[row, col] == 'O')
                {
                    foreach (var item in pillarLocation)
                    {
                        matrix[item[0], item[1]] = '-';
                        row = item[0];
                        col = item[1];
                    }
                }
            }

            if (flag)
            {
                matrix[row, col] = 'S';
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
