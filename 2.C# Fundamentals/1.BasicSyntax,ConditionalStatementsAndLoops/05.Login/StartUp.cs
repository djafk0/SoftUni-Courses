using System;

class Program
{
    static string ReverseString(string s)
    {
        // Convert to char array, then call Array.Reverse.
        // ... Finally use string constructor on array.
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    static void Main()
    {
        string username = Console.ReadLine();

        for (int i = 0; i < int.MaxValue; i++)
        {
            if (i == 3)
            {
                Console.WriteLine($"User {username} blocked!");
                break;
            }
            string password = Console.ReadLine();
            if (password != ReverseString(username))
            {
                Console.WriteLine($"Incorrect password. Try again.");
                continue;
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
                break;
            }
        }
    }
}