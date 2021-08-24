using System;

namespace _1.__Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int n = 0;
            foreach (var item in input)
            {
                if (item.Length >= 3 && item.Length <= 16)
                {
                    foreach (var chara in item)
                    {
                        if (char.IsLetterOrDigit(chara) || chara == '-' || chara == '_')
                        {
                            n++;
                            if (n == item.Length)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
                n = 0;
            }
        }
    }
}

