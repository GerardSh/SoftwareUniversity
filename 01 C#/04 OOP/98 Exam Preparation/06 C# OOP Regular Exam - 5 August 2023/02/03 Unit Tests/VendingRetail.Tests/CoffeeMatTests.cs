using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class CoffeeMatTests
    {
        CoffeeMat coffee;

        [SetUp]
        public void Setup()
        {
            coffee = new CoffeeMat(10, 10);
        }

        [Test]
        public void ConstructorShouldCreateObject()
        {
            Assert.IsNotNull(coffee);
            Assert.That(coffee.ButtonsCount, Is.EqualTo(10));
            Assert.That(coffee.Income, Is.EqualTo(0));
            Assert.That(coffee.WaterCapacity, Is.EqualTo(10));
        }

        [Test]
        public void FillWaterTankMethodShouldWorkCorrectly()
        {
            string result = coffee.FillWaterTank();

            Assert.That(result, Is.EqualTo("Water tank is filled with 10ml"));

            result = coffee.FillWaterTank();

            Assert.That(result, Is.EqualTo("Water tank is already full!"));
        }

        [Test]
        public void AddDrinkMethodShouldWorkCorrectly()
        {
            coffee = new CoffeeMat(10, 2);

            bool result = coffee.AddDrink("drink", 10);

            Assert.True(result);

            result = coffee.AddDrink("drink", 10);

            Assert.False(result);

            result = coffee.AddDrink("drink2", 10);

            Assert.True(result);

            result = coffee.AddDrink("drink3", 10);

            Assert.False(result);
        }

        [Test]
        public void BuyDrinkMethodShouldWorkCorrectly()
        {
            coffee = new CoffeeMat(100, 3);

            coffee.AddDrink("drink", 10);
            coffee.AddDrink("drink2", 12.50);

            string result = coffee.BuyDrink("drink");

            Assert.That(result, Is.EqualTo("CoffeeMat is out of water!"));

            coffee.FillWaterTank();

            result = coffee.BuyDrink("drink3");

            Assert.That(result, Is.EqualTo("drink3 is not available!"));

            Assert.That(coffee.Income, Is.EqualTo(0));

            result = coffee.BuyDrink("drink");

            Assert.That(coffee.Income, Is.EqualTo(10));
            Assert.That(result, Is.EqualTo("Your bill is 10.00$"));

           result= coffee.BuyDrink("drink2");

            Assert.That(result, Is.EqualTo("CoffeeMat is out of water!"));

            coffee.FillWaterTank();

            result = coffee.BuyDrink("drink2");

            Assert.That(result, Is.EqualTo("Your bill is 12.50$"));

            Assert.That(coffee.Income, Is.EqualTo(22.50));
        }

        [Test]
        public void CollectIncomeMethodShouldWorkCorrectly()
        {
            coffee = new CoffeeMat(100, 3);

            coffee.AddDrink("drink", 10);
            coffee.AddDrink("drink2", 20);

            coffee.FillWaterTank();

            coffee.BuyDrink("drink");

            coffee.FillWaterTank();

            coffee.BuyDrink("drink2");

            Assert.That(coffee.Income, Is.EqualTo(30));

            double result = coffee.CollectIncome();

            Assert.That(coffee.Income, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(30));
        }
    }
}