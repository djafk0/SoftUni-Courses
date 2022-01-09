using System;
using System.Collections.Generic;

namespace _7.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vip.Remove(input);
                }
                else
                {
                    regular.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(regular.Count + vip.Count);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
