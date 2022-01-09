namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {

        [Test]
        public void ConstructorShouldWorksCorectly()
        {
            RobotManager robotManager = new RobotManager(3);

            Assert.AreEqual(3, robotManager.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowsAnExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void Count()
        {
            RobotManager robotManager = new RobotManager(4);
            robotManager.Add(new Robot("sad", 60));
            robotManager.Add(new Robot("sad2", 60));
            robotManager.Add(new Robot("sad3", 60));

            Assert.AreEqual(3, robotManager.Count);
        }

        [Test]
        public void AddMethodShouldThrowsAnExceptionWithSameName()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("sad", 60);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddMethodShouldThrowsAnExceptionWhenIsOutOfCapacity()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));
            robotManager.Add(new Robot("sad2", 60));
            robotManager.Add(new Robot("sad3", 60));

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("sad4", 60)));
        }

        [Test]
        public void AddMethodShouldWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));
            robotManager.Add(new Robot("sad2", 60));

            Assert.DoesNotThrow(() => robotManager.Add(new Robot("sad4", 60)));
        }

        [Test]
        public void RemoveMethodShouldThrowsAnExceptionWhenIsNull()
        {
            RobotManager robotManager = new RobotManager(3);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(null));
        }
        [Test]
        public void RemoveMethodShouldThrowsAnExceptionWhenIsEmptySpace()
        {
            RobotManager robotManager = new RobotManager(3);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(""));
        }

        [Test]
        public void RemoveMethodShouldWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));

            Assert.DoesNotThrow(() => robotManager.Remove("sad"));
        }

        [Test]
        public void WorkMethodShouldThrowsAnExceptionWithNull()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(null, "vajna", 60));
        }

        [Test]
        public void WorkMethodShouldThrowsAnExceptionWithEmptyString()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("", "vajna", 60));
        }

        [Test]
        public void WorkMethodShouldThrowsAnExceptionWithLessBattery()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("sad", "vajna", 70));
        }

        [Test]
        public void WorkMethodShouldWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("sad", 60));

            Assert.DoesNotThrow(() => robotManager.Work("sad", "vajna", 30));
        }

        [Test]
        public void WorkMethodShouldWorksCorrectly2()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("sad", 60);
            robotManager.Add(robot);
            robotManager.Work("sad", "vajna", 30);

            Assert.AreEqual(30, robot.Battery);
        }

        [Test]
        public void ChargeMethodShouldThrowsAnExceptionWithEmptyString()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("sad", 60);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(""));
        }

        [Test]
        public void ChargeMethodShouldThrowsAnExceptionWithNull()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("sad", 60);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(null));
        }

        [Test]
        public void ChargeMethodShouldWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(3);
            Robot robot = new Robot("sad", 50);
            robotManager.Add(robot);
            robotManager.Work("sad", "vajna", 30);
            robotManager.Charge("sad");

            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }

        //public void Charge(string robotName)
        //{
        //    Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

        //    if (robot == null)
        //    {
        //        throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
        //    }

        //    robot.Battery = robot.MaximumBattery;
        //}

    }
}
