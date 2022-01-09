using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }
        public bool CanDrive(double distance)
            => this.FuelQuantity - (distance * this.FuelConsumption) >= 0;
        public void Drive(double distance)
        {
            this.FuelQuantity -= distance * this.FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
