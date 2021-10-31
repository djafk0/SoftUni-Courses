namespace _6.SpeedRacing
{
    public class Tire
    {
        public double TireOnePressure { get; set; }
        public int TireOneAge { get; set; }
        public double TireTwoPressure { get; set; }
        public int TireTwoAge { get; set; }
        public double TireThreePressure { get; set; }
        public int TireThreeAge { get; set; }
        public double TireForthPressure { get; set; }
        public int TireForthAge { get; set; }

        public bool Contains(int pressure)
        {
            if (TireOnePressure < pressure || TireTwoPressure < pressure || TireThreePressure < pressure || TireForthPressure < pressure)
            {
                return true;
            }

            return false;

        }
    }
}
