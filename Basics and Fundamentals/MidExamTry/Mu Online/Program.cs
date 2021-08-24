using System;
using System.Linq;

namespace Mu_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            int health = 100;
            int bitcoins = 0;
            bool isDead = false;
            for (int i = 0; i < arr.Length; i++)
            {
                string[] type = arr[i].Split();
                if (type[0] == "potion")
                {
                    int x = 0;
                    int some = 0;
                    health += int.Parse(type[1]);
                    if (health > 100)
                    {
                        x = health - 100;
                        some = x - int.Parse(type[1]);
                        health -= x;
                        Console.WriteLine($"You healed for {Math.Abs(some)} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {type[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (type[0] == "chest")
                {
                    bitcoins += int.Parse(type[1]);
                    Console.WriteLine($"You found {type[1]} bitcoins.");
                }
                else
                {
                    health -= int.Parse(type[1]);

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {type[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {type[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        isDead = true;
                        break;
                    }
                }
            }
            if (!isDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
