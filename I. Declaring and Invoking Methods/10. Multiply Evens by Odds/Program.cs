using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = 0;
            int oddSum = 0;

            for (int i = numbers; numbers > 0; i *= 1)
            {
                int oneNumber = numbers % 10;
                numbers /= 10;
                if (oneNumber % 2 == 0)
                {
                    evenSum += oneNumber;
                }
                else
                {
                    oddSum += oneNumber;
                }
            }
            int result = evenSum * oddSum;
            Console.WriteLine(result);
        }
    }
}
