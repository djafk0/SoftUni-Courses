using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var footballBetting = new FootballBettingContext();
            footballBetting.Database.EnsureDeleted();
            footballBetting.Database.EnsureCreated();
            Console.WriteLine("ok");
        }
    }
}
