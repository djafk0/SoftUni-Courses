using System;
using System.Text;

namespace Problem_1._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            string[] command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Generate")
            {
                if (command[0] == "Contains")
                {
                    bool isFound = sb.ToString().Contains(command[1]);
                    if (isFound)
                    {
                        Console.WriteLine($"{sb} contains {command[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (command[0] == "Flip")
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);
                    if (command[1] == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = char.ToUpper(sb[i]);
                        }
                    }
                    else if (command[1] == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = char.ToLower(sb[i]);
                        }
                    }
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Slice")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    sb.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(sb);
                }

                command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your activation key is: {sb}");
        }
    }
}
