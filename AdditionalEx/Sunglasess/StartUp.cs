using System;

namespace Sunglasess
{
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string a = "*";
            string space = " ";
            string b = "/";
            string c = "|";

            for (int j = 1; j <= n * 2; j++)
            {
                Console.Write(a);
            }
            for (int k = 1; k <= n; k++)
            {
                Console.Write(space);
            }
            for (int l = 1; l <= n * 2; l++)
            {
                Console.Write(a);
            }
            Console.WriteLine();
            for (int m = 1; m <= n - 2; m++)
            {
                Console.Write(a);
                for (int o = 1; o <= n * 2 - 2; o++)
                {
                    Console.Write(b);
                }
                Console.Write(a);
                if (n % 2 != 0)
                {
                    if (n / 2 == m)
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            Console.Write(c);
                        }
                    }
                    else
                    {
                        for (int k = 1; k <= n; k++)
                        {
                            Console.Write(space);
                        }
                    }
                }
                else
                {
                    if (n / 2 == m + 1)
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            Console.Write(c);
                        }
                    }
                    else
                    {
                        for (int k = 1; k <= n; k++)
                        {
                            Console.Write(space);
                        }
                    }
                }
                Console.Write(a);
                for (int s = 1; s <= n * 2 - 2; s++)
                {
                    Console.Write(b);
                }
                Console.WriteLine(a);
            }
            for (int t = 1; t <= n * 2; t++)
            {
                Console.Write(a);
            }
            for (int u = 1; u <= n; u++)
            {
                Console.Write(space);
            }
            for (int v = 1; v <= n * 2; v++)
            {
                Console.Write(a);
            }
        }
    }
}
