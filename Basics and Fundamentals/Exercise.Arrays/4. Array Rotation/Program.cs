using System;
using System.Linq;

namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotations; i++)
            {
                int savedNumber = arr[0];
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j < arr.Length - 1)
                    {
                        arr[j] = arr[j + 1];
                    }
                }
                arr[arr.Length - 1] = savedNumber;
            }
            
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
