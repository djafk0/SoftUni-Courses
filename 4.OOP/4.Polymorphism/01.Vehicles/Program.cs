using System;

namespace _1.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine().Split(' ');
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                double value = double.Parse(command[2]);

                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(double.Parse(command[2]));
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (command[1] == "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(double.Parse(command[2]));
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
