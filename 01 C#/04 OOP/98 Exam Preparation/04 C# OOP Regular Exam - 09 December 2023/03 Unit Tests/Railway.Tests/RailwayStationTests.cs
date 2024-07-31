namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class RailwayStationTests
    {
        RailwayStation railway;

        [SetUp]
        public void Setup()
        {
            railway = new RailwayStation("name");
        }

        [Test]
        public void ConstructorShouldCreateObjectCorrectly()
        {
            Assert.IsNotNull(railway);
            Assert.That(railway.Name, Is.EqualTo("name"));
            Assert.That(railway.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railway.DepartureTrains.Count, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("")]
        public void NamePropertyShouldThrowExceptionIfNullOrEmptyValueIsGiven(string name)
        {
            Assert.Throws<ArgumentException>(() => railway = new RailwayStation(name));
        }

        [Test]
        public void NewArrivalOnBoardMethodShouldWorkCorrectly()
        {
            Assert.That(railway.ArrivalTrains.Count, Is.EqualTo(0));

            railway.NewArrivalOnBoard("train");

            Assert.That(railway.ArrivalTrains.Count, Is.EqualTo(1));
        }

        [Test]
        public void TrainHasArrivedMethodShouldCorrectInformation()
        {
            railway.NewArrivalOnBoard("train");

            string result = railway.TrainHasArrived("train2");

            Assert.That(result, Is.EqualTo("There are other trains to arrive before train2."));

            Assert.That(railway.ArrivalTrains.Count, Is.EqualTo(1));
            Assert.That(railway.DepartureTrains.Count, Is.EqualTo(0));

            result = railway.TrainHasArrived("train");

            Assert.That(railway.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railway.DepartureTrains.Count, Is.EqualTo(1));

            Assert.That(result, Is.EqualTo("train is on the platform and will leave in 5 minutes."));
        }

        [Test]
        public void TrainHasLeftMethodShouldReturnCorrectInformation()
        {
            railway.NewArrivalOnBoard("train");
            railway.TrainHasArrived("train");

            bool result = railway.TrainHasLeft("train");

            Assert.That(railway.DepartureTrains.Count, Is.EqualTo(0));

            Assert.True(result);

            railway.NewArrivalOnBoard("train");
            railway.TrainHasArrived("train");

            result = railway.TrainHasLeft("train2");

            Assert.False(result);
        }
    }
}