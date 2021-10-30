using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];

            for (int i = 0; i < n; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    row[j] = jagged[i - 1][j] + jagged[i - 1][j - 1];
                }

                jagged[i] = row;
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
    }
}
