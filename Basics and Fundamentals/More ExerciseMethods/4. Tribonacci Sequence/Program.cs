using System;
using System.Numerics;

namespace _4._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[] result = TribonacciNumbers(n);

            Console.WriteLine(String.Join(' ', result));
        }

        private static BigInteger[] TribonacciNumbers(int n)
        {
            BigInteger[] result = new BigInteger[n];

            switch (n)
            {
                case 1:
                    result[0] = 1;
                    break;
                case 2:
                    result[0] = 1;
                    result[1] = 1;
                    break;
                case 3:
                    result[0] = 1;
                    result[1] = 1;
                    result[2] = 2;
                    break;
                default:
                    result[0] = 1;
                    result[1] = 1;
                    result[2] = 2;
                    for (int i = 3; i < n; i++)
                    {
                        BigInteger currNum = result[i - 3] + result[i - 2] + result[i - 1];
                        result[i] = currNum;
                    }
                    break;
            }

            return result;
        }
    }
}