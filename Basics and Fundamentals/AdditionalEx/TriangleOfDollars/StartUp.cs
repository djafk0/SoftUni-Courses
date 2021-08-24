using System;

namespace TriangleOfDollars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "$";
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
