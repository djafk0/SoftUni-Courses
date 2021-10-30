using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int wholeCake = cakeLength * cakeWidth;
            int piecesTaken = 0;

            string pieces = Console.ReadLine().ToUpper();

            while (pieces != "STOP")
            {
                piecesTaken = int.Parse(pieces);
                wholeCake = wholeCake - piecesTaken;

                if (wholeCake < 0)
                {
                    Console.WriteLine("No more cake left! You need {0} pieces more.", Math.Abs(wholeCake));
                    break;
                }
                pieces = Console.ReadLine().ToUpper();
            }
            if (pieces == "STOP")
            {
                Console.WriteLine("{0} pieces are left.", wholeCake);
            }
        }
    }
}
