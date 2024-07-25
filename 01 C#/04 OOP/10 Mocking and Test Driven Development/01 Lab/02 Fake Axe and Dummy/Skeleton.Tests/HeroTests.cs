﻿using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void AttackMethodShouldGiveExperienceIfTargetIsKilledUsingMOQ()
        {
            var myWeapon = new Mock<IWeapon>();

            var myTarget = new Mock<ITarget>();

            myTarget.Setup(x => x.IsDead())
                .Returns(true);

            myTarget.Setup(x => x.GiveExperience())
                .Returns(100);

            Hero hero = new Hero("Hero", myWeapon.Object);

            hero.Attack(myTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(100));
        }
    }
}
