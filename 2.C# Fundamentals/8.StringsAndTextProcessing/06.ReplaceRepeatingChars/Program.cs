using System;
using System.Text;

namespace _6.__Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            for (int i = 1; i < sb.Length; i++)
            {
                if (sb[i] == sb[i-1])
                {
                    sb.Remove(i, 1);
                    i--;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
