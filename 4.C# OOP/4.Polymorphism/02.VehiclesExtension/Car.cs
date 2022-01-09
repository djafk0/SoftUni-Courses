using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private const double FuelIncreaseConsuption = 0.9;

        public Car(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {
        }

        public override double FuelConsuptionPerKm
            => base.FuelConsuptionPerKm + FuelIncreaseConsuption;
    }
}
