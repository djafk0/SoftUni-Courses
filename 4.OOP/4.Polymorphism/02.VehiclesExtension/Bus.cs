using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Bus : Vehicle
    {
        private const double FuelIncreaseConsuption = 1.4;

        public Bus(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {
        }

        public bool IsEmpty { get; private set; }

        public override double FuelConsuptionPerKm => this.IsEmpty
            ? base.FuelConsuptionPerKm
            : base.FuelConsuptionPerKm + FuelIncreaseConsuption;

        public string DriveEmpty(double distance)
        {
            this.IsEmpty = true;
            string result = base.Drive(distance);
            this.IsEmpty = false;

            return result;
        }
    }
}
