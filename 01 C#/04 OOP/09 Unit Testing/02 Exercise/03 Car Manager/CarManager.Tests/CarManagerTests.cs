namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        const string DefaultMake = "TestMake";
        const string DefaultModel = "TestModel";
        const double DefaultFuelConsumption = 5.5;
        const double DefaultFuelCapacity = 90.5;

        Car defaultCar;

        [SetUp]
        public void Setup()
        {
            defaultCar = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
        }

        [Test]
        public void ConstructorShouldCreateCarObjectWithAllSpecifiedParameters()
        {
            Assert.That(defaultCar, Is.Not.Null);
            Assert.That(defaultCar.Make, Is.EqualTo(DefaultMake));
            Assert.That(defaultCar.Model, Is.EqualTo(DefaultModel));
            Assert.That(defaultCar.FuelConsumption, Is.EqualTo(DefaultFuelConsumption));
            Assert.That(defaultCar.FuelCapacity, Is.EqualTo(DefaultFuelCapacity));
            Assert.That(defaultCar.FuelAmount, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakePropertyShouldThrowArgumentExceptionIfValueIsNullOrEmpty(string value)
        {
            Assert.That(() => new Car(value, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelPropertyShouldThrowArgumentExceptionIfValueIsNullOrEmpty(string value)
        {
            Assert.That(() => new Car(DefaultMake, value, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionPropertyShouldThrowArgumentExceptionIfValueIsZeroOrNegative(double value)
        {
            Assert.That(() => new Car(DefaultMake, DefaultModel, value, DefaultFuelCapacity), Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityPropertyShouldThrowArgumentExceptionIfValueIsZeroOrNegative(double value)
        {
            Assert.That(() => new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, value), Throws.ArgumentException);
        }

        //Аnother option to check the setters of the properties
        //[TestCase(null, "Model", 10.0, 100.0)]
        //[TestCase("", "Model", 10.0, 100.0)]
        //[TestCase("Make", null, 10.0, 100.0)]
        //[TestCase("Make", "", 10.0, 100.0)]
        //[TestCase("Make", "Model", 0, 100.0)]
        //[TestCase("Make", "Model", -10.0, 100.0)]
        //[TestCase("Make", "Model", 10.0, 0)]
        //[TestCase("Make", "Model", 10.0, -100.0)]
        //public void PropertiesShouldThrowErrorWhenValueIsInvalid
        //                         (string make, string model, double fuelConsumption, double fuelCapacity)
        //{
        //    Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        //}

        [TestCase(1)]
        [TestCase(DefaultFuelCapacity)]
        [TestCase(DefaultFuelCapacity + 1)]
        public void RefuelMethodShouldRefuelTheFuelAmountWithTheSpecifiedValue(double value)
        {
            double result = defaultCar.FuelAmount + value;

            if (result > defaultCar.FuelCapacity)
            {
                result = defaultCar.FuelCapacity;
            }

            defaultCar.Refuel(value);

            Assert.That(result, Is.EqualTo(defaultCar.FuelAmount));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowArgumentExceptionIfValueToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.That(() => defaultCar.Refuel(fuelToRefuel), Throws.ArgumentException);
        }

        [Test]
        public void DriveMethodShouldThrowInvalidOperationExceptionIfAmountOfFuelIsNotEnough()
        {
            Assert.That(() => defaultCar.Drive(10), Throws.InvalidOperationException);
        }

        [Test]
        public void DriveMethodShouldCorrectlyReduceTheAmountOfFuel()
        {
            Car car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);

            car.Refuel(0.55);
            car.Drive(10);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
    }
}