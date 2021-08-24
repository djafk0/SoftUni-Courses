using System;
using System.Text;

namespace _4.__Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int bla = input[i] + 3;
                sb.Append((char)bla); 
            }
            Console.WriteLine(sb);
        }
    }
}
