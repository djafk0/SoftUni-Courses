using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool flag = false;
            int counter = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (counter > n)
                    {
                        flag = true;
                        break;
                    }
                    Console.Write(counter + " ");
                    counter++;
                }
                Console.WriteLine();
                if (flag)
                {
                    break;
                }
            }
        }
    }
}
