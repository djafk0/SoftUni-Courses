using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                int index = int.Parse(command);
                if (index >= input.Count)
                {
                    command = Console.ReadLine();
                    continue;
                }
                int currNum = input[index];
                input.RemoveAt(index);
                input.Insert(index, -1);
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] > currNum)
                    {
                        if (i == index)
                        {
                            continue;
                        }
                        input[i] -= currNum;
                    }
                    else
                    {
                        if (i == index || input[i] == -1)
                        {
                            continue;
                        }
                        input[i] += currNum;
                    }
                }



                command = Console.ReadLine();
            }
            int counter = input.Count;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] != -1)
                {
                    counter--;
                }
            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(' ', input)}");
        }
    }
}
