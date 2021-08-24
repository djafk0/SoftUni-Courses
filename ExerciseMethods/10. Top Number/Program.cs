using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 0;
            int sum = 0;
            bool isOneOddDigit = false;
            for (int i = 1; i <= n; i++)
            {
                number = i;

                for (int j = 0; number > 0;)
                {
                    sum += number % 10;
                    if (sum % 2 == 1)
                    {
                        isOneOddDigit = true;
                    }
                    number /= 10;
                }
                if (sum % 8 == 0 && isOneOddDigit)
                {я
                    Console.WriteLine(i);
                }
                isOneOddDigit = false;
                sum = 0;
            }
        }
    }
}
