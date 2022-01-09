using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsuptionPerKm { get; }

        public double TankCapacity { get; }

        public string Drive(double distance);

        public void Refuel(double fuelAmount);
    }
}
