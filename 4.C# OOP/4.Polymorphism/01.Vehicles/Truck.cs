using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
         => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
