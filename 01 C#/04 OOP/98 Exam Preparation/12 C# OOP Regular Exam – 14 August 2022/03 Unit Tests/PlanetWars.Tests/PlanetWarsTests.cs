using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    [TestFixture]
    public class PlanetWarsTests
    {
        Weapon weapon;
        Planet planet;

        [SetUp]
        public void SetUp()
        {
            weapon = new Weapon("name", 10, 10);
            planet = new Planet("name", 10);
        }

        [Test]
        public void ConstructorsShouldCreateObjectsAndThrowExceptionsWhenNeeded()
        {
            Assert.IsNotNull(weapon);
            Assert.That(weapon.Name, Is.EqualTo("name"));
            Assert.That(weapon.Price, Is.EqualTo(10));
            Assert.That(weapon.DestructionLevel, Is.EqualTo(10));
            Assert.Throws<ArgumentException>(() => new Weapon("name", -1, 10));
            Assert.That(weapon.IsNuclear, Is.EqualTo(true));

            weapon.IncreaseDestructionLevel();

            Assert.That(weapon.DestructionLevel, Is.EqualTo(11));
            
            weapon.DestructionLevel = 0;

            Assert.That(weapon.IsNuclear, Is.EqualTo(false));

            Assert.Throws<ArgumentException>(() => new Planet("", 10));
            Assert.Throws<ArgumentException>(() => new Planet(null, 10));
            Assert.Throws<ArgumentException>(() => new Planet("planet", -1));

            Assert.IsNotNull(planet);
            Assert.IsNotNull(planet.Weapons);
            Assert.That(planet.Name, Is.EqualTo("name"));
            Assert.That(planet.Budget, Is.EqualTo(10));
            Assert.That(planet.Weapons.Count, Is.EqualTo(0));        
        }

        [Test]
        public void ProfitMethodShouldWorkCorrectly()
        {
            Assert.That(planet.Budget, Is.EqualTo(10));
            planet.Profit(10);
            Assert.That(planet.Budget, Is.EqualTo(20));
        }

        [Test]
        public void SpendFundsMethodShouldWorkCorrectly()
        {
            Assert.That(planet.Budget, Is.EqualTo(10));
            Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(11));

            planet.SpendFunds(10);
           
            Assert.That(planet.Budget, Is.EqualTo(0));
        }

        [Test]
        public void AddWeaponMethodShouldWorkCorrectly()
        {
            Weapon weapon2 = new Weapon("name", 10, 10);

            Assert.That(planet.Weapons.Count, Is.EqualTo(0));

            planet.AddWeapon(weapon);

            Assert.That(planet.Weapons.Count, Is.EqualTo(1));

            Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon2));

            Assert.That(planet.Weapons.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveWeaponMethodShouldWorkCorrectly()
        {
            Weapon weapon2 = new Weapon("name2", 10, 10);

            Assert.That(planet.Weapons.Count, Is.EqualTo(0));

            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon2);

            Assert.That(planet.Weapons.Count, Is.EqualTo(2));

            planet.RemoveWeapon("name3");

            Assert.That(planet.Weapons.Count, Is.EqualTo(2));

            planet.RemoveWeapon("name2");

            Assert.That(planet.Weapons.Count, Is.EqualTo(1));
        }

        [Test]
        public void UpgradeWeaponMethodShouldWorkCorrectly()
        {
            Weapon weapon2 = new Weapon("name2", 10, 10);

            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon2);

            Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("name3"));

            Assert.That(weapon2.DestructionLevel, Is.EqualTo(10));

            planet.UpgradeWeapon("name2");

            Assert.That(weapon2.DestructionLevel, Is.EqualTo(11));
        }

        [Test]
        public void DestructOpponentMethodShouldWorkCorrectly()
        {
            Weapon weapon2 = new Weapon("name2", 10, 10);

            Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(0));

            planet.AddWeapon(weapon);
            planet.AddWeapon(weapon2);

            Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(20));

            Planet planet2 = new Planet("name2", 10);

            planet2.AddWeapon(weapon);
            planet2.AddWeapon(weapon2);

            Assert.That(planet2.MilitaryPowerRatio, Is.EqualTo(20));

            Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet2));
            Assert.Throws<InvalidOperationException>(() => planet2.DestructOpponent(planet));

            planet2.RemoveWeapon("name2");

            Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(20));
            Assert.That(planet2.MilitaryPowerRatio, Is.EqualTo(10));

            string result = planet.DestructOpponent(planet2);

            Assert.That(result, Is.EqualTo("name2 is destructed!"));
        }
    }
}
