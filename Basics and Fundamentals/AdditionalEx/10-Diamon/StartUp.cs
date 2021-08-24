using System;

namespace _10_Diamond
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "*";
            string b = "-";

            if (n == 1)
            {
                Console.WriteLine("*");
            }
            else
            {

                if (n % 2 == 0)
                {
                    for (int i = 1; i <= n / 2; i++)
                    {
                        for (int j = 1; j <= n / 2 - i; j++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int k = 1; k <= i * 2 - 2; k++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int j = 1; j <= n / 2 - i; j++)
                        {
                            Console.Write(b);
                        }
                        Console.WriteLine();
                    }
                    for (int l = 2; l <= n / 2; l++)
                    {
                        for (int m = 1; m <= l - 1; m++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int o = 1; o <= n - (2 * l); o++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int m = 1; m <= l - 1; m++)
                        {
                            Console.Write(b);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    for (int w = 1; w <= n / 2; w++)
                    {
                        Console.Write(b);
                    }
                    Console.Write(a);
                    for (int e = 1; e <= n / 2; e++)
                    {
                        Console.Write(b);
                    }
                    Console.WriteLine();
                    for (int q = 1; q <= n / 2; q++)
                    {
                        for (int r = 1; r <= n / 2 - q; r++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int t = 1; t <= q * 2 - 1; t++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int r = 1; r <= n / 2 - q; r++)
                        {
                            Console.Write(b);
                        }
                        Console.WriteLine();
                    }
                    for (int i = 2; i <= n / 2; i++)
                    {
                        for (int y = 2; y <= i; y++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int u = 1; u <= n - 2 * i; u++)
                        {
                            Console.Write(b);
                        }
                        Console.Write(a);
                        for (int y = 2; y <= i; y++)
                        {
                            Console.Write(b);
                        }
                        Console.WriteLine();
                    }
                    for (int w = 1; w <= n / 2; w++)
                    {
                        Console.Write(b);
                    }
                    Console.Write(a);
                    for (int e = 1; e <= n / 2; e++)
                    {
                        Console.Write(b);
                    }
                }
            }
        }
    }
}
