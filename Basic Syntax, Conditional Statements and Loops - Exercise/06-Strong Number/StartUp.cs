using System;

namespace _06_Strong_Number
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int firstnumber = input; 

            int sum = 0;

            while (input > 0)
            {
                int currNum = input % 10;

                int factoriel = 1;

                for (int i = 1; i <= currNum; i++)
                {
                    factoriel *= i;
                }

                sum += factoriel;

                input /= 10;
            }
            if (firstnumber == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        } 
    }
}
