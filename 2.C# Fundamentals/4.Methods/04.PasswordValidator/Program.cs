using System;

namespace _4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int counter = 0;
            counter = CharCounter(password, counter);
            counter = LetterOrDiggitCounter(password, counter);
            counter = DigitCounter(password, counter);
            IsValidPrint(counter);
        }

        private static void IsValidPrint(int counter)
        {
            if (counter == 3)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static int DigitCounter(string password, int counter)
        {
            int diggitCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    diggitCounter++;
                }
            }
            if (diggitCounter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return counter;
            }
            counter++;
            return counter;
        }

        private static int LetterOrDiggitCounter(string password, int counter)
        {
            int letterOrDiggitCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLetterOrDigit(password[i]))
                {
                    letterOrDiggitCounter++;
                }
            }
            if (letterOrDiggitCounter != password.Length)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                return counter;
            }
            counter++;
            return counter;
        }

        private static int CharCounter(string password, int counter)
        {
            if (6 > password.Length || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return counter;
            }
            counter++;
            return counter;
        }
    }
}
