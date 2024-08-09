using NUnit.Framework;
using System.Xml.Linq;

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
        public void ConstructorShouldCreateTheObject()
        {
            Assert.IsNotNull(coffee);
            Assert.That(coffee.WaterCapacity, Is.EqualTo(10));
            Assert.That(coffee.ButtonsCount, Is.EqualTo(10));
            Assert.That(coffee.Income, Is.EqualTo(0));

            string result = coffee.FillWaterTank();

            Assert.That(result, Is.EqualTo("Water tank is filled with 10ml"));

            bool drinkAdded = coffee.AddDrink("drink", 10);

            Assert.True(drinkAdded);
        }

        [Test]
        public void FillWaterTankMethodShouldReturnCorrectValues()
        {
            string result = coffee.FillWaterTank();

            Assert.That(result, Is.EqualTo("Water tank is filled with 10ml"));

            result = coffee.FillWaterTank();

            Assert.That(result, Is.EqualTo($"Water tank is already full!"));
        }

        [Test]
        public void AddDrinkShouldReturnCorrectValues()
        {
            coffee = new CoffeeMat(10, 2);

            bool result = coffee.AddDrink("drink", 1);

            Assert.True(result);

            result = coffee.AddDrink("drink", 1);

            Assert.False(result);

            result = coffee.AddDrink("drink2", 2);

            Assert.True(result);

            result = coffee.AddDrink("drink3", 3);

            Assert.False(result);
        }

        [Test]
        public void BuyDrinkMethodShouldReturnCorrectValues()
        {
            coffee.AddDrink("drink", 1);

            string result = coffee.BuyDrink("drink");

            Assert.That(result, Is.EqualTo($"CoffeeMat is out of water!"));

            coffee = new CoffeeMat(80, 3);
            coffee.FillWaterTank();

            coffee.AddDrink("drink", 1);

            result = coffee.BuyDrink("drink2");

            Assert.That(result, Is.EqualTo("drink2 is not available!"));
            Assert.That(coffee.Income, Is.EqualTo(0));

            result = coffee.BuyDrink("drink");

            Assert.That(result, Is.EqualTo("Your bill is 1.00$"));
            Assert.That(coffee.Income, Is.EqualTo(1));

            result = coffee.BuyDrink("drink");

            Assert.That(result, Is.EqualTo($"CoffeeMat is out of water!"));
        }

        [Test]
        public void CollectIncomeShouldReturnCorrectValues()
        {
            Assert.That(coffee.Income, Is.EqualTo(0));

            coffee = new CoffeeMat(80, 3);
            coffee.FillWaterTank();
            coffee.AddDrink("drink", 1);

            double result = coffee.CollectIncome();

            Assert.That(result, Is.EqualTo(0));

            Assert.That(coffee.Income, Is.EqualTo(0));

            coffee.BuyDrink("drink");

            Assert.That(coffee.Income, Is.EqualTo(1));

            result = coffee.CollectIncome();

            Assert.That(coffee.Income, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(1));
        }
    }
}