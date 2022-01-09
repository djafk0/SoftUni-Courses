using System;
using System.Linq;

namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int checker = 0;
            int saveChecker = 0;
            int middle = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                middle = i;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (middle > j)
                    {
                        leftSum += arr[j];
                    }
                    
                    else if (middle < j)
                    {
                        rightSum += arr[j];
                    }
                    if (leftSum == rightSum)
                    {
                        saveChecker = checker;
                    }
                }
                checker++;
            }
            if (saveChecker != 0)
            {
                Console.WriteLine(saveChecker);
            }
            else if (middle == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
