using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class RobotFactoryTests
    {
        Factory factory;
        Robot robot;
        Supplement supplement;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("name", 10);
            robot = new Robot("model", 10, 100);
            supplement = new Supplement("name", 100);
        }

        [Test]
        public void ObjectConstructorsShouldCreateObjects()
        {
            Assert.IsNotNull(factory);
            Assert.IsNotNull(robot);
            Assert.IsNotNull(supplement);
            Assert.That(supplement.Name, Is.EqualTo("name"));
            Assert.That(supplement.InterfaceStandard, Is.EqualTo(100));
            Assert.That(supplement.ToString(), Is.EqualTo("Supplement: name IS: 100"));
            Assert.That(robot.Model, Is.EqualTo("model"));
            Assert.That(robot.Price, Is.EqualTo(10));
            Assert.That(robot.InterfaceStandard, Is.EqualTo(100));
            Assert.That(robot.Supplements.Count, Is.EqualTo(0));
            Assert.That(robot.ToString(), Is.EqualTo("Robot model: model IS: 100, Price: 10.00"));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Name, Is.EqualTo("name"));
            Assert.That(factory.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void RobotClassSupplementsListShouldAddAndRemoveValuesCorrectly()
        {
            var supplement2 = new Supplement("name2", 200);

            Assert.That(robot.Supplements.Count, Is.EqualTo(0));

            robot.Supplements.Add(supplement);

            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

            robot.Supplements.Add(supplement2);

            Assert.That(robot.Supplements.Count, Is.EqualTo(2));

            robot.Supplements.Remove(supplement2);

            Assert.That(robot.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void FactoryClassSupplementsAndRobotsListsShouldAddAndRemoveValuesCorrectly()
        {
            var robot2 = new Robot("model2", 20, 200);
            var supplement2 = new Supplement("name2", 200);

            Assert.That(factory.Robots.Count, Is.EqualTo(0));

            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);

            Assert.That(factory.Robots.Count, Is.EqualTo(2));

            factory.Robots.Remove(robot2);

            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));

            factory.Supplements.Add(supplement);
            factory.Supplements.Add(supplement2);

            Assert.That(factory.Supplements.Count, Is.EqualTo(2));

            factory.Supplements.Remove(supplement2);

            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void ProduceRobotMethodShouldReturnCorrectValues()
        {
            factory.Capacity = 1;

            string result = factory.ProduceRobot("model2", 20, 200);

            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(factory.Robots[0].Model, Is.EqualTo("model2"));
            Assert.That(factory.Robots[0].Price, Is.EqualTo(20));
            Assert.That(result, Is.EqualTo($"Produced --> Robot model: model2 IS: 200, Price: {20:f2}"));

            result = factory.ProduceRobot("model3", 30, 300);

            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo("The factory is unable to produce more robots for this production day!"));
        }

        [Test]
        public void ProduceSupplementMethodShouldReturnCorrectValues()
        {
            string result = factory.ProduceSupplement("name2", 200);

            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements[0].Name, Is.EqualTo("name2"));
            Assert.That(factory.Supplements[0].InterfaceStandard, Is.EqualTo(200));
            Assert.That(result, Is.EqualTo("Supplement: name2 IS: 200"));
        }

        [Test]
        public void PUpgradeRobotMethodShouldReturnCorrectValues()
        {
            robot.Supplements.Add(supplement);

            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

            bool result = factory.UpgradeRobot(robot, supplement);

            Assert.False(result);
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

            var supplement2 = new Supplement("name2", 200);

            result = factory.UpgradeRobot(robot, supplement2);

            Assert.False(result);
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

            var supplement3 = new Supplement("name3", 100);

            result = factory.UpgradeRobot(robot, supplement3);

            Assert.True(result);
            Assert.That(robot.Supplements.Count, Is.EqualTo(2));
        }

        [Test]
        public void SellRobotMethodShouldReturnCorrectValues()
        {
            var robot2 = new Robot("model2", 20, 200);

            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);

            var result = factory.SellRobot(30);

            Assert.That(result, Is.EqualTo(robot2));
            Assert.That(result.Model, Is.EqualTo(robot2.Model));
            Assert.That(result.Price, Is.EqualTo(robot2.Price));

            result = factory.SellRobot(9);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}