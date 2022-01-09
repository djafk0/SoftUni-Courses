using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public bool CanDrive(double distance);
        public void Drive(double distance);

        public void Refuel(double liters);
    }
}
