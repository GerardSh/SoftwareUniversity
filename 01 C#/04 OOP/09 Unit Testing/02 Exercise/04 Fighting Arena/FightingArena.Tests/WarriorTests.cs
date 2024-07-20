namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        const string Name = "name";
        const int Damage = 100;
        const int HP = 200;

        Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(Name, Damage, HP);
        }

        [TestCase("", Damage, HP)]
        [TestCase(" ", Damage, HP)]
        [TestCase(Name, 0, HP)]
        [TestCase(Name, -1, HP)]
        [TestCase(Name, Damage, -1)]
        public void PropertiesShouldThrowArgumentExceptionWhenInvalidValueIsGiven(string name, int damage, int hP)
        {
            Assert.That(() => new Warrior(name, damage, hP), Throws.ArgumentException);
            Assert.That(() => new Warrior(name, damage, hP), Throws.ArgumentException);
        }

        public void ConstructorShouldCreateWarriorAndSetAllPropertyValuesCorrectly(string name, int damage, int hP)
        {
            Assert.That(warrior.Name, Is.EqualTo(Name));
            Assert.That(warrior.Damage, Is.EqualTo(Damage));
            Assert.That(warrior.HP, Is.EqualTo(HP));
        }

        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethodShouldThrowInvalidOperationExceptionWhenWarriorHpIsBelowOrEqualToMinAttackHp(int hP)
        {
            warrior = new Warrior(Name, Damage, hP);

            Assert.That(() => warrior.Attack(new Warrior("EnemyWarrior", 100, 200)), Throws.InvalidOperationException);
        }

        [TestCase(30)]
        [TestCase(29)]
        public void AttackMethodShouldThrowInvalidOperationExceptionWhenEnemyWarriorHpIsBelowOrEqualToMinAttackHp(int hP)
        {
            Assert.That(() => warrior.Attack(new Warrior(Name, Damage, hP)), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionWhenHpIsLowerThanEnemyWarriorDamage()
        {
            Assert.That(() => warrior.Attack(new Warrior(Name, HP + 1, HP)), Throws.InvalidOperationException);
        }

        [TestCase(200, 0)]
        [TestCase(199, 1)]
        public void AttackMethodShouldReduceWarriorHpWhenNoErrorIsThrown(int damage, int remainingHp)
        {
            warrior.Attack(new Warrior(Name, damage, HP));

            Assert.That(warrior.HP, Is.EqualTo(remainingHp));
        }

        [TestCase(99)]
        [TestCase(100)]
        [TestCase(101)]
        public void AttackMethodShouldReduceEnemyWarriorHpWhenNoErrorIsThrown(int enemyHp)
        {
            Warrior enemyWarrior = new Warrior(Name, Damage, enemyHp);

            warrior.Attack(enemyWarrior);

            int result = 0;

            if (warrior.Damage < enemyHp)
            {
                result = enemyHp - warrior.Damage;
            }

            Assert.That(result, Is.EqualTo(enemyWarrior.HP));
        }
    }
}