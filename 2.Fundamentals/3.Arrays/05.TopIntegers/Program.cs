using System;
using System.Linq;

namespace _5._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[arr.Length - 1])
                {
                    continue;
                }
                if (arr[i] > arr[i + 1])
                {
                    
                    Console.Write(arr[i] + " ");

                }
            }
            Console.Write(arr[arr.Length - 1]);
        }
    }
}
