using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        Smartphone smartPhone;
        Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartPhone = new Smartphone("model", 10);
            shop = new Shop(10);
        }

        [Test]
        public void ConstructorShouldCreateObjects()
        {
            Assert.IsNotNull(smartPhone);
            Assert.IsNotNull(shop);

            Assert.That(smartPhone.ModelName, Is.EqualTo("model"));
            Assert.That(smartPhone.MaximumBatteryCharge, Is.EqualTo(10));
            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(smartPhone.MaximumBatteryCharge));

            Assert.That(shop.Capacity, Is.EqualTo(10));
            Assert.That(shop.Count, Is.EqualTo(0));
            Assert.Throws<ArgumentException>(() => new Shop(-1));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            var smartPhone2 = new Smartphone("model2", 10);
            shop = new Shop(3);

            Assert.That(shop.Count, Is.EqualTo(0));

            shop.Add(smartPhone);

            Assert.That(shop.Count, Is.EqualTo(1));
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartPhone));
            shop.Add(smartPhone2);
            Assert.That(shop.Count, Is.EqualTo(2));
            shop.Add(new Smartphone("model3", 30));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("model4", 40)));
            Assert.That(shop.Count, Is.EqualTo(shop.Capacity));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            var smartPhone2 = new Smartphone("model2", 10);
            Assert.That(shop.Count, Is.EqualTo(0));
            shop.Add(smartPhone);
            shop.Add(smartPhone2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("model3"));
            Assert.That(shop.Count, Is.EqualTo(2));

            shop.Remove("model2");

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestPhoneMethodShouldWorkCorrectly()
        {
            var smartPhone2 = new Smartphone("model2", 10);

            shop.Add(smartPhone);
            shop.Add(smartPhone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("model3", 10));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("model2", 11));

            Assert.That(smartPhone2.CurrentBateryCharge, Is.EqualTo(10));

            shop.TestPhone("model2", 10);

            Assert.That(smartPhone2.CurrentBateryCharge, Is.EqualTo(0));

            shop.TestPhone("model", 5);

            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(5));
        }

        [Test]
        public void ChargePhoneMethodShouldWorkCorrectly()
        {
            var smartPhone2 = new Smartphone("model2", 10);

            shop.Add(smartPhone);
            shop.Add(smartPhone2);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("model3"));

            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(10));

            shop.TestPhone("model", 10);

            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(0));

            shop.ChargePhone("model");

            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(10));
            Assert.That(smartPhone.CurrentBateryCharge, Is.EqualTo(smartPhone.MaximumBatteryCharge));
        }
    }
}