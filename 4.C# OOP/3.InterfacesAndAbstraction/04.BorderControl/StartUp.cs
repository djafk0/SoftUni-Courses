using System;
using System.Collections.Generic;

namespace _4.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<string> ids = new List<string>();

            while (input[0] != "End")
            {
                if (input.Length == 2)
                {
                    ids.Add(input[1]);
                }
                else if (input.Length == 3)
                {
                    ids.Add(input[2]);
                }

                input = Console.ReadLine().Split(' ');
            }

            string fakeId = Console.ReadLine();

            foreach (var id in ids)
            {
                if (id.Substring(id.Length - fakeId.Length) == fakeId)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
