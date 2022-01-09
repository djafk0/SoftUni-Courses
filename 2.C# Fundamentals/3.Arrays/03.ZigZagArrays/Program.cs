using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int [n];
            int[] secondArray = new int [n];

            for (int i = 0; i < n; i++)
            {
                int[] read = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                if (i % 2 == 0)
                {
                    firstArray[i] = read[0];
                    secondArray[i] = read[1]; 
                }
                else
                {
                    firstArray[i] = read[1];
                    secondArray[i] = read[0];
                }
            }
            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
