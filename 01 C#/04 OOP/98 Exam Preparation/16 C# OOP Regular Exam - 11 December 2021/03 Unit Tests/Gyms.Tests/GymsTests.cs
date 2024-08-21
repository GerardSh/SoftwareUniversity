using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        Athlete athlete;
        Gym gym;

        [SetUp]
        public void Setup()
        {
            athlete = new Athlete("name");
            gym = new Gym("name", 10);
        }

        [Test]
        public void ConstructorsShouldCreateObjectsCorrectly()
        {
            Assert.NotNull(athlete);
            Assert.That(athlete.FullName, Is.EqualTo("name"));
            Assert.That(athlete.IsInjured, Is.EqualTo(false));

            Assert.NotNull(gym);
            Assert.That(gym.Name, Is.EqualTo("name"));
            Assert.That(gym.Capacity, Is.EqualTo(10));
            Assert.That(gym.Count, Is.EqualTo(0));

            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Gym("", 10));
            Assert.Throws<ArgumentException>(() => new Gym("name", -1));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Athlete athlete2 = new Athlete("name2");
            Athlete athlete3 = new Athlete("name3");
            gym = new Gym("name", 2);

            Assert.That(gym.Count, Is.EqualTo(0));

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.That(gym.Count, Is.EqualTo(2));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete3));

            Assert.That(gym.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Athlete athlete2 = new Athlete("name2");
            Athlete athlete3 = new Athlete("name3");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.That(gym.Count, Is.EqualTo(3));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("name4"));

            Assert.That(gym.Count, Is.EqualTo(3));

            gym.RemoveAthlete("name3");

            Assert.That(gym.Count, Is.EqualTo(2));
        }

        [Test]
        public void InjureAthleteMethodShouldWorkCorrectly()
        {
            Athlete athlete2 = new Athlete("name2");
            Athlete athlete3 = new Athlete("name3");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("name4"));

            Assert.That(athlete2.IsInjured, Is.False);

            Athlete result = gym.InjureAthlete("name2");

            Assert.That(athlete2.IsInjured, Is.True);
            Assert.That(result.IsInjured, Is.True);
            Assert.That(result, Is.EqualTo(athlete2));
        }

        [Test]
        public void ReportMethodShouldWorkCorrectly()
        {
            Athlete athlete2 = new Athlete("name2");
            Athlete athlete3 = new Athlete("name3");
            
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete("name3");

            string result = gym.Report();

            Assert.That(result, Is.EqualTo($"Active athletes at name: name, name2"));

            gym = new Gym("name", 10);

            result = gym.Report();

            Assert.That(result, Is.EqualTo($"Active athletes at name: "));
        }
    }
}
