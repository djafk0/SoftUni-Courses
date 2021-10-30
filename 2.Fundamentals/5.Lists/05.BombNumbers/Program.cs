using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombAndArea = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bomb = bombAndArea[0];
            int area = bombAndArea[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    for (int j = 0; j < area; j++)
                    {
                        if (i + j == numbers.Count - 1)
                        {
                            break;
                        }
                        numbers[i + j + 1] = 0;
                    }
                    for (int j = 0; j < area; j++)
                    {
                        if (i - j == 0)
                        {
                            break;
                        }
                        numbers[i - j - 1] = 0;
                    }
                    numbers[i] = 0;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
