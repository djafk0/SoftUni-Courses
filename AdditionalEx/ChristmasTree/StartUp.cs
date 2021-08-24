using System;

namespace ChristmasTree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "|";
            string b = "*";
            string space = " ";
            for (int i = 0; i <= n; i++)
            {
                for (int k = i; k < n; k++)
                {
                    Console.Write(space);
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(b);
                }
                Console.Write(space);
                Console.Write(a);
                Console.Write(space);
                for (int l = 1; l <= i; l++)
                {
                    Console.Write(b);
                }
                for (int m = i; m < n; m++)
                {
                    Console.Write(space);
                }
                Console.WriteLine();
            }
        }
    }
}
