using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        const int AxeAttack = 10;
        const int AxeDurability = 10;
        const int DummyHealth = 10;
        const int DummyExperience = 10;

        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AttackShouldLooseOneDurabilityPointAfterAttacking()
        {
            Axe axe = new Axe(AxeAttack, AxeDurability);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void AttackShouldThrowExceptionIfDurabilityIsLessThanOrEqualsZero(int durabilityPoints)
        {
            Axe axe = new Axe(AxeAttack, durabilityPoints);

            //1
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");

            //2
            //Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "Axe is broken.");
        }
    }
}