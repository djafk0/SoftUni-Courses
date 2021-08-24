using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int numbers = n;
            int sum = 0;
            while (n > 0)
            {
                numbers = n % 10;
                sum += numbers;
                n /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
