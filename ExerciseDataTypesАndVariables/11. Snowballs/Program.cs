using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger currentResult = 0;
            BigInteger result = 0;
            int snowballSnowSaved = 0;
            int snowballTimeSaved = 0; 
            int snowballQualitySaved = 0;
            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                currentResult = BigInteger.Pow((snowballSnow / snowballTime),snowballQuality);
                if (currentResult >= result)
                {
                    result = currentResult;
                    snowballSnowSaved = snowballSnow;
                    snowballTimeSaved = snowballTime;
                    snowballQualitySaved = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowSaved} : {snowballTimeSaved} = {result} ({snowballQualitySaved})");
        }
    }
}
