using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        const int AttackPoints = 10;
        const int DummyHealth = 10;
        const int DummyExperience = 10;

        Dummy dummy;

        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void TakeAttackShouldCauseLostOfHealthPoints()
        {
            dummy.TakeAttack(AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(0), "Not loosing the correct amount of health points.");
        }

        [Test]
        public void TakeAttackShouldThrowExceptionIfDummyIsDead()
        {
            dummy.TakeAttack(AttackPoints);

            Assert.That(() => dummy.TakeAttack(AttackPoints), Throws.InvalidOperationException, "Dummy is dead.");
        }

        [Test]
        public void GiveExperienceShouldGiveExperienceIfDummyIsDead()
        {
            dummy.TakeAttack(AttackPoints);

            int result = dummy.GiveExperience();

            Assert.That(result, Is.EqualTo(DummyExperience), "Dummy did not give the correct amount of experience points.");
        }

        [Test]
        public void GiveExperienceShouldThrowExceptionIfDummyIsAlive()
        {
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Dummy is alive.");
        }
    }
}