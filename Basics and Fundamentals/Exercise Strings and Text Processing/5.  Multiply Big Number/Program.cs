using System;
using System.Text;

namespace _5.__Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            int mind = 0;
            bool reminder = false;

            if (b == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int last = int.Parse(a[i].ToString());
                int sum = 0;
                if (reminder)
                {
                    sum = last * b + mind;
                    reminder = false;
                }
                else
                {
                    sum = last * b;
                }
                if (sum < 10)
                {
                    sb.Insert(0, sum);
                }
                else
                {
                    if (i == 0)
                    {
                        sb.Insert(0, sum);
                        continue;
                    }
                    mind = sum % 10;
                    sb.Insert(0, mind);
                    mind = sum / 10;
                    reminder = true;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
