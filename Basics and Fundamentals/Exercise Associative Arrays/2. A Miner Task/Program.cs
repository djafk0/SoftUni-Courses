using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> input = new Dictionary<string, int>();
            string command = Console.ReadLine();
            string currentItem = "";
            bool isOdd = true;
            while (command != "stop")
            {
                if (isOdd)
                {
                    if (!input.ContainsKey(command))
                    {
                        input.Add(command, 0);
                    }
                    currentItem = command;
                    isOdd = false;
                }
                else
                {
                    input[currentItem] += int.Parse(command);
                    isOdd = true;
                }

                command = Console.ReadLine();
            }
            foreach (var item in input)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
