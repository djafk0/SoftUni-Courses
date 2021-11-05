using System;
using System.Collections.Generic;

namespace _6.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            string command = Console.ReadLine();

            while (songs.Count != 0)
            {
                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command.Substring(0, 3) == "Add")
                {
                    if (songs.Contains(command.Substring(4)))
                    {
                        Console.WriteLine($"{command.Substring(4)} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(command.Substring(4));
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
