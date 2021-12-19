using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ConstructorTest()
        {
            Gym gym = new Gym("sad", 30);
            
            Assert.IsNotNull(gym);
        }

        [Test]
        public void ConstructorTestName()
        {
            Gym gym = new Gym("sad", 30);

            Assert.AreEqual("sad", gym.Name);
        }

        [Test]
        public void ConstructorTestName2()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 30));
        }

        [Test]
        public void ConstructorTestName3()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 30));
        }

        [Test]
        public void ConstructorTestSize()
        {
            Gym gym = new Gym("sad", 30);

            Assert.AreEqual(30, gym.Capacity);
        }

        [Test]
        public void ConstructorTestSize2()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Sad", -5));
        }

        [Test]
        public void ConstructorTestSize3()
        {
            Gym gym = new Gym("sad", 0);
            Assert.IsNotNull(gym);
        }

        [Test]
        public void CountTest()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            Assert.AreEqual(3, gym.Count);
        }

        [Test]
        public void CountTest2()
        {
            Gym gym = new Gym("saddd", 30);

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void AddAthlete()
        {
            Gym gym = new Gym("sad", 0);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("sad")));
        }

        [Test]
        public void AddAthlete2()
        {
            Gym gym = new Gym("sad", 3);

            Assert.DoesNotThrow(() => gym.AddAthlete(new Athlete("sad")));
        }

        [Test]
        public void RemoveAthlete()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            gym.RemoveAthlete("sad");

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void RemoveAthlete2()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            gym.RemoveAthlete("sad");

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("sad"));
        }

        [Test]
        public void RemoveAthlete3()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            gym.RemoveAthlete("sad");

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(null));
        }

        [Test]
        public void InjureAthlete()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            gym.RemoveAthlete("sad");

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("sad"));
        }

        [Test]
        public void InjureAthlete2()
        {
            Gym gym = new Gym("saddd", 30);

            gym.AddAthlete(new Athlete("sad"));
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            gym.RemoveAthlete("sad");

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void InjureAthlete3()
        {
            Gym gym = new Gym("saddd", 30);
            Athlete athlete = new Athlete("sad");
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            Assert.AreEqual(athlete, gym.InjureAthlete("sad"));
        }

        [Test]
        public void InjureAthlete4()
        {
            Gym gym = new Gym("saddd", 30);
            Athlete athlete = new Athlete("sad");
            athlete.IsInjured = false;
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void InjureAthlete5()
        {
            Gym gym = new Gym("saddd", 30);
            Athlete athlete = new Athlete("sad");
            athlete.IsInjured = true;
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            Assert.IsTrue(athlete.IsInjured);
        }

        [Test]
        public void Report()
        {
            Gym gym = new Gym("saddd", 30);
            Athlete athlete = new Athlete("sad");
            athlete.IsInjured = true;
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("sad2"));
            gym.AddAthlete(new Athlete("sad3"));

            Assert.AreEqual("Active athletes at saddd: sad2, sad3", gym.Report());
        }

        [Test]
        public void Report2()
        {
            Gym gym = new Gym("saddd", 30);
            Athlete athlete = new Athlete("sad");
            athlete.IsInjured = true;
            gym.AddAthlete(athlete);
            Athlete athlete2 = new Athlete("sad2");
            athlete2.IsInjured = true;
            gym.AddAthlete(athlete2);
            Athlete athlete3 = new Athlete("sad3");
            athlete3.IsInjured = true;
            gym.AddAthlete(athlete3);

            Assert.AreEqual("Active athletes at saddd: ", gym.Report());
        }


        //public string Report()
        //{
        //    string athleteNames = string.Join(", ", this.athletes.Where(x => !x.IsInjured).Select(f => f.FullName));
        //    string report = $"Active athletes at {this.Name}: {athleteNames}";

        //    return report;
        //}

    }
}
