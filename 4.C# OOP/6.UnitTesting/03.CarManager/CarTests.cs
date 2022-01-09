using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5)]
        [TestCase("BMW", "e36", 8.8, 60.4)]
        public void ConstructorShouldWorksCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase("", "Golf", 5.5, 50.5)]
        [TestCase(null, "Corolla", 5.1, 55.5)]
        public void PropertyMakeCannotBeNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity), "Make cannot be null or empty!");
        }

        [Test]
        [TestCase("VW", "", 5.5, 50.5)]
        [TestCase("Toyota", null, 5.1, 55.5)]
        public void PropertyModelCannotBeNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity), "Model cannot be null or empty!");
        }

        [Test]
        [TestCase("VW", "Golf", 0, 50.5)]
        [TestCase("Toyota", "Corolla", double.MinValue, 55.5)]
        public void PropertyFuelConsumptionCannotBeZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity), "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 0)]
        [TestCase("Toyota", "Corolla", 5.1, double.MinValue)]
        public void PropertyFuelCapacityCannotBeZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5, 0)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5, double.MinValue)]
        public void RefuelMethodShouldThrowsExceptionWhitZeroOrNegative(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5, 20)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5, 30)]
        public void RefuelMethodShouldWorksCorrectlyWhenFuelToRefuelIsLessThanTheCapacity(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5, double.MaxValue)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5, 60)]
        public void RefuelMethodShouldWorksCorrectlyWhenFuelToRefuelIsAboveTheCapacity(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5, 1.1, 5000)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5, 0.5, 3200)]
        public void DriveMethodShouldThrowsExceptionWhenFuelNeededIsMoreThanFuelAmount(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance), "You don't have enough fuel to drive!");
        }

        [Test]
        [TestCase("VW", "Golf", 5.5, 50.5, 50, 5)]
        [TestCase("Toyota", "Corolla", 5.1, 55.5, 30, 3)]
        public void DriveMethodShouldWorksCorrectly(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            double fuelNeeded = (distance / 100) * fuelConsumption;
            double fuelLeft = car.FuelAmount - fuelNeeded;

            car.Drive(distance);

            Assert.AreEqual(fuelLeft, car.FuelAmount);
        }

    }
}