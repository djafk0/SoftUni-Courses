using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> modifier = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "end")
            {
                
                if (command[0] == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstNumber = modifier[firstIndex];
                    int secondNumber = modifier[secondIndex];
                    modifier.RemoveAt(firstIndex);
                    modifier.Insert(firstIndex, secondNumber);
                    modifier.RemoveAt(secondIndex);
                    modifier.Insert(secondIndex, firstNumber);
                }
                else if (command[0] == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstNumber = modifier[firstIndex];
                    int secondNumber = modifier[secondIndex];
                    int result = firstNumber * secondNumber;
                    modifier.RemoveAt(firstIndex);
                    modifier.Insert(firstIndex, result);
                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < modifier.Count; i++)
                    {
                        modifier[i]--;
                    }
                }


                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(", ", modifier));
        }
    }
}
