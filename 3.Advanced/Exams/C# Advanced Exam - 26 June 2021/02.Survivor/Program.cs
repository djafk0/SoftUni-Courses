using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] jagged = new char[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int myTokens = 0;
            int oppTokens = 0;
            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] action = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(action[1]);
                int col = int.Parse(action[2]);

                if (action[0] == "Find" && row >= 0 && row <= n && col >= 0 && col < jagged[row].Length)
                {
                    myTokens++;
                    jagged[row][col] = '-';
                }
                else if (action[0] == "Opponent" && row >= 0 && row <= n && col >= 0 && col < jagged[row].Length)
                {
                    oppTokens++;
                    jagged[row][col] = '-';

                    for (int i = 1; i < 4; i++)
                    {
                        if (action[3] == "up" && row - i >= 0 && row - i <= n && col >= 0 && col < jagged[row].Length)
                        {
                            if (char.IsLetter(jagged[row - i][col]))
                            {
                                oppTokens++;
                                jagged[row - i][col] = '-';
                            }
                        }
                        else if (action[3] == "down" && row + i >= 0 && row + i <= n && col >= 0 && col < jagged[row].Length)
                        {
                            if (char.IsLetter(jagged[row + i][col]))
                            {
                                oppTokens++;
                                jagged[row + i][col] = '-';
                            }
                        }
                        else if (action[3] == "left" && row >= 0 && row <= n && col - i >= 0 && col - i < jagged[row].Length)
                        {
                            if (char.IsLetter(jagged[row][col - i]))
                            {
                                jagged[row][col - i] = '-';
                                oppTokens++;
                            }
                        }
                        else if (action[3] == "right" && row >= 0 && row <= n && col + i >= 0 && col + i < jagged[row].Length)
                        {
                            if (char.IsLetter(jagged[row][col + i]))
                            {
                                oppTokens++;
                                jagged[row][col + i] = '-';
                            }
                        }
                    }

                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(' ', jagged[i]));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {oppTokens}");
        }

    }
}
