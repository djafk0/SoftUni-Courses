using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> drumSetInput = new List<int>();
            for (int i = 0; i < drumSet.Count; i++)
            {
                drumSetInput.Add(drumSet[i]);
            }
            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int integer = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    int currNum = drumSet[i];
                    currNum -= integer;

                    if (currNum <= 0)
                    {

                        if (savings < 3 * drumSetInput[i])
                        {
                            drumSet.RemoveAt(i);
                            drumSetInput.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            savings -= 3 * drumSetInput[i];
                            drumSet.RemoveAt(i);
                            drumSet.Insert(i, drumSetInput[i]);
                        }
                    }
                    else
                    {
                        drumSet.RemoveAt(i);
                        drumSet.Insert(i, currNum);
                    }
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
            // savings = 154 - 9 = 145 - 15 = 130 - 24 = 106 - 9 = 97 - 15 = 82 - 24 = 58 - 9 = 49 - 15 = 34 - 24 = 10
            //start : 55 111 3 5 8 50
            //- 2 = 53 109 1 3 6 48 
            //- 50 = 3 59 3 5 8
            //- 8 = 51 3 5 8
            //- 23 = 28 3 5 8 
            //- 1 = 27 2 4 7
        }
    }
}
