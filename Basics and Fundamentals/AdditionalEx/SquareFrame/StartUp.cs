using System;

namespace SquareFrame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "+ ";
            string b = "- ";
            string c = "| ";

            Console.Write(a);
            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(b);
            }
            Console.WriteLine(a);

            for (int l = 1; l <= n - 2; l++)
            {
                Console.Write(c);
                for (int j = 1; j <= n - 2; j++)
                {
                    Console.Write(b);
                }
                Console.WriteLine(c);
            }

            Console.Write(a);
            for (int k = 1; k <= n - 2; k++)
            {
                Console.Write(b);
            }
            Console.Write(a);
        }
    }
}
