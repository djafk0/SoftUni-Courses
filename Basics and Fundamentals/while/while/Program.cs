using System;

namespace whileа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool flag = false;
            int current = 1;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (current > n)
                    {
                        flag = true;
                        break;
                    }
                    Console.Write($"{current} ");
                    current++;
                }
                if (flag)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
