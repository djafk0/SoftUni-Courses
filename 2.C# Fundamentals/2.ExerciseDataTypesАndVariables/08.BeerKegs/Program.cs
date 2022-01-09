using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggerKeg = 0;
            string kegName = "";
            for (int i = 0; i < n; i++)
            {
                string currentKegName = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currentKeg = Math.PI * radius * radius * height;
                if (biggerKeg < currentKeg)
                {
                    biggerKeg = currentKeg;
                    kegName = currentKegName;
                }
            }
            Console.WriteLine(kegName);
        }
    }
}
