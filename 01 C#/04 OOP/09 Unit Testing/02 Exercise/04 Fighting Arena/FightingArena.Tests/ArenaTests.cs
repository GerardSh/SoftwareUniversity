namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        const int Damage = 100;
        const int HP = 200;

        Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldCreateObject()
        {
            Assert.That(arena, Is.Not.Null);
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollMethodShouldThrowInvalidOperationExceptionWhenWarriorWithTheSameNameIsAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Warrior", 10, 10);

            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorCorrectlyWhenNoOtherWarriorWithTheSameNameIsFound()
        {
            Warrior warrior = new Warrior("Warrior", 10, 10);
            Warrior warrior2 = new Warrior("Warrior2", 10, 10);

            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));

            arena.Enroll(warrior2);

            Assert.That(arena.Count, Is.EqualTo(2));
        }

        [TestCase("Warrior", "Warrior3")]
        [TestCase("Warrior3", "Warrior2")]
        public void FightMethodShouldThrowInvalidOperationExceptionWhenAttackerOrDefenderAreMissingFromCollection(
            string attackerName,
            string defenderName)
        {
            Warrior attackerWarrior = new Warrior("Warrior", Damage, HP);
            Warrior defenderWarrior = new Warrior("Warrior2", Damage, HP);

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            Assert.That(() => arena.Fight(attackerName, defenderName), Throws.InvalidOperationException);

            string missingName = "Warrior3";

            Assert.That(() => arena.Fight(attackerName, defenderName), Throws.InvalidOperationException.With.Message.Contain(missingName));
        }

        [Test]
        public void FightMethodShouldCorrectlyReduceHpOfBothDefenderAndAttacker()
        {
            Warrior attackerWarrior = new Warrior("Warrior", Damage, HP);
            Warrior defenderWarrior = new Warrior("Warrior2", Damage, HP);

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            arena.Fight("Warrior", "Warrior2");

            foreach (var warrior in arena.Warriors)
            {
                Assert.That(warrior.HP, Is.EqualTo(100));
            }
        }
    }
}
