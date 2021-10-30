using System;
using System.Linq;

namespace _4.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i] * 1.2;
            }

            foreach (var item in input)
            {
                Console.WriteLine(string.Join("", item.ToString("F2")));
            }

        }
    }
}
