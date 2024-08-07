using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class RepairsShopTests
    {
        Car car;
        Garage garage;

        [SetUp]
        public void Setup()
        {
            car = new Car("model", 10);
            garage = new Garage("name", 10);
        }

        [Test]
        public void ConstructorsShouldCreateObjects()
        {
            Assert.IsNotNull(car);
            Assert.That(car.CarModel, Is.EqualTo("model"));
            Assert.That(car.NumberOfIssues, Is.EqualTo(10));
            Assert.False(car.IsFixed);

            car.NumberOfIssues = 0;

            Assert.True(car.IsFixed);

            Assert.IsNotNull(garage);
            Assert.That(garage.CarsInGarage, Is.EqualTo(0));
            Assert.That(garage.Name, Is.EqualTo("name"));
            Assert.That(garage.MechanicsAvailable, Is.EqualTo(10));

            Assert.Throws<ArgumentNullException>(() => new Garage("", 10));
            Assert.Throws<ArgumentNullException>(() => new Garage(null, 10));
            Assert.Throws<ArgumentException>(() => new Garage("name", 0));
            Assert.Throws<ArgumentException>(() => new Garage("name", -1));
        }

        [Test]
        public void AddCarMethodShouldWorkCorrectly()
        {
            garage = new Garage("name", 1);

            Assert.That(garage.CarsInGarage, Is.EqualTo(0));

            garage.AddCar(car);

            Assert.That(garage.CarsInGarage, Is.EqualTo(1));
            Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));
            Assert.That(garage.CarsInGarage, Is.EqualTo(1));
        }

        [Test]
        public void FixCarMethodShouldWorkCorrectly()
        {
            Car car2 = new Car("model2", 2);

            garage.AddCar(car);
            garage.AddCar(car2);

            Assert.Throws<InvalidOperationException>(() => garage.FixCar("model3"));

            Assert.That(car2.NumberOfIssues, Is.EqualTo(2));

            Car fixedCar = garage.FixCar("model2");

            Assert.That(car2.NumberOfIssues, Is.EqualTo(0));
            Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            Assert.That(fixedCar, Is.EqualTo(car2));
        }

        [Test]
        public void RemoveFixedCarMethodShouldWorkCorrectly()
        {
            Car car2 = new Car("model2", 2);
            Car car3 = new Car("model3", 3);

            garage.AddCar(car);
            garage.AddCar(car2);
            garage.AddCar(car3);

            Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            Assert.That(garage.CarsInGarage, Is.EqualTo(3));
            Assert.That(car2.NumberOfIssues, Is.EqualTo(2));

            garage.FixCar("model");
            garage.FixCar("model2");

            int result = garage.RemoveFixedCar();

            Assert.That(car.NumberOfIssues, Is.EqualTo(0));
            Assert.That(car2.NumberOfIssues, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(2));
            Assert.That(garage.CarsInGarage, Is.EqualTo(1));
        }

        [Test]
        public void ReportMethodShouldWorkCorrectly()
        {
            Car car2 = new Car("model2", 2);

            string result = garage.Report();

            Assert.That(result, Is.EqualTo($"There are 0 which are not fixed: ."));

            garage.AddCar(car);
            garage.AddCar(car2);

            result = garage.Report();

            Assert.That(result, Is.EqualTo($"There are 2 which are not fixed: model, model2."));
        }
    }
}