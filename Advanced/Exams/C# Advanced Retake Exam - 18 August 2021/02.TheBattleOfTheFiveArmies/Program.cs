using System;

namespace _02.TheBattleОfТheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];

            int row = 0;
            int col = 0;

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().ToCharArray();

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (jagged[i][j] == 'A')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int enemyRow = 0;
            int enemyCol = 0;

            while (true)
            {
                enemyRow = int.Parse(command[1]);
                enemyCol = int.Parse(command[2]);

                jagged[enemyRow][enemyCol] = 'O';
                jagged[row][col] = '-';

                if (command[0] == "up")
                {
                    if (row - 1 >= 0)
                    {
                        row--;
                    }
                }
                else if (command[0] == "down")
                {
                    if (row + 1 < n)
                    {
                        row++;
                    }
                }
                else if (command[0] == "left")
                {
                    if (col - 1 >= 0)
                    {
                        col--;
                    }
                }
                else if (command[0] == "right")
                {
                    if (col + 1 < n)
                    {
                        col++;
                    }
                }

                armor--;

                if (armor <= 0)
                {
                    Console.WriteLine($"The army was defeated at {row};{col}.");
                    jagged[row][col] = 'X';
                    break;
                }
                if (jagged[row][col] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    jagged[row][col] = '-';
                    break;
                }
                else if (jagged[row][col] == 'O')
                {
                    armor -= 2;

                    if (armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {row};{col}.");
                        jagged[row][col] = 'X';
                        break;
                    }
                    else
                    {
                        jagged[row][col] = 'M';
                    }
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join("", jagged[i]));
            }
        }
    }
}
