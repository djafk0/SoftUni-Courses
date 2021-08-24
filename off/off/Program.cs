using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToList();
            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();
            for (int i = 0; i < input.Count; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add((int)Char.GetNumericValue(input[i]));
                }
                else
                {
                    nonNumbers.Add(input[i]);
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            List<char> output = new List<char>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            int indexOfPlayList = 0;
            int sum = takeList.Sum();
            for (int i = 0; i < nonNumbers.Count;)
            {
                for (int j = 0; j < takeList[indexOfPlayList]; j++)
                {
                    if (sum == output.Count)
                    {
                        break;
                    }
                    output.Add(nonNumbers[i]);
                    i++;
                }
                if (sum == output.Count)
                {
                    break;
                }
                for (int j = 0; j < skipList[indexOfPlayList]; j++)
                {
                    if (sum == output.Count)
                    {
                        break;
                    }
                    i++;
                }
                indexOfPlayList++;
            }
            Console.WriteLine(string.Join("", output));
        }
    }
}
