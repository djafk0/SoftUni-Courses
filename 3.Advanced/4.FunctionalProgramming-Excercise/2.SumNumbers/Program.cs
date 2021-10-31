using System;
using System.Linq;
using System.Text;

namespace _2.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][0] == char.ToUpper(input[i][0]))
                {
                    sb.AppendLine(input[i]);
                }
            }

            Console.WriteLine(string.Join("", sb));
        }
    }
}
