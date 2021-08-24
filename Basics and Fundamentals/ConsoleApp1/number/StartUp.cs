using System;

namespace number
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num <= 100 && num >= -100 && num != 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
