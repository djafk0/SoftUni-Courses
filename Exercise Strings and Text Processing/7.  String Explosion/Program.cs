using System;
using System.Text;

namespace _7.__String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            int power = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                }
                if (power > 0 && input[i] != '>')
                {
                    input.Remove(i, 1);
                    power--;
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
