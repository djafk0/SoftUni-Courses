using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "";
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floors; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floors)
                    {
                        x = "L";
                    }
                    else if (i % 2 == 0)
                    {
                        x = "O";
                    }
                    else if (i % 2 != 0)
                    {
                        x = "A";
                    }
                    Console.Write($"{x}{i}{j} ");
                }

                Console.WriteLine();
            }
        }
    }
}
