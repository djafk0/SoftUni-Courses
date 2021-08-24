using System;

namespace fundamentals6
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;
            int counter = 0;
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }
            while (true)
            {
                string currentPassword = Console.ReadLine();

                if (currentPassword != password)
                {
                    counter++;

                    if (counter == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                    }
                    Console.WriteLine($"Incorrect password. Try again.");
                    
                }
                else
                {
                    Console.WriteLine($"User {userName} logged in.");
                    return;
                }
            }
        }
    }
}
