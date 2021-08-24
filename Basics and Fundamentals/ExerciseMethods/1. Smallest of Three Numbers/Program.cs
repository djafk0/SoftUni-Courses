using System;

namespace _1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallestNumber = int.MaxValue;
            smallestNumber = MinOfThree(smallestNumber);
            Console.WriteLine(smallestNumber);
        }

        private static int MinOfThree(int smallestNumber)
        {
            for (int i = 0; i < 3; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (smallestNumber > currentNumber)
                {
                    smallestNumber = currentNumber;
                }
            }

            return smallestNumber;
        }
    }
}
