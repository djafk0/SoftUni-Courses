using System;

namespace _09_House
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "*";
            string b = "-";
            string c = "|";

            for (int i = 1; i <= (n + 1) / 2; i++)
            {
                if (n % 2 == 0)
                {
                    for (int j = 1; j <= n / 2 - i; j++)
                    {
                        Console.Write(b);
                    }
                    for (int l = 1; l <= i * 2; l++)
                    {
                        Console.Write(a);
                    }
                    for (int j = 1; j <= n / 2 - i; j++)
                    {
                        Console.Write(b);
                    }
                }
                else
                {
                    for (int k = 1; k <= n / 2 - i + 1 ; k++)
                    {
                        Console.Write(b);
                    }
                    for (int m = 1; m <= i * 2 - 1; m++)
                    {
                        Console.Write(a);
                    }
                    for (int k = 1; k <= n / 2 - i + 1; k++)
                    {
                        Console.Write(b);
                    }
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n / 2 ; i++)
            {
                Console.Write(c);
                for (int p = 1; p <= n - 2; p++)
                {
                    Console.Write(a);
                }
                Console.WriteLine(c);
            }
        }
    }
}
