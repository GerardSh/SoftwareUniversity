using System;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    HeroRepository heroRepository;
    Hero hero;


    [SetUp]
    public void Setup()
    {
        heroRepository = new HeroRepository();
        hero = new Hero("Hero", 60);
    }

    [Test]
    public void ConstructorHeroShouldCreateTheObject()
    {
        Assert.That(hero.Name, Is.EqualTo("Hero"));
        Assert.That(hero.Level, Is.EqualTo(60));
        Assert.That(hero, Is.Not.Null);
    }

    [Test]
    public void ConstructorHeroRepositoryShouldCreateTheObject()
    {
        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(0));
        Assert.That(heroRepository.Heroes, Is.Not.Null);
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenNullIsGiven()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateMethodShouldThrowExceptionWhenTheHeroWithTheSameNameExists()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldAddTheHeroCorrectly()
    {
        Assert.That(heroRepository.Heroes.Count == 0);

        heroRepository.Create(hero);

        Assert.That(heroRepository.Heroes.Count == 1);
        Assert.True(heroRepository.Heroes.Contains(hero));
    }

    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveMethodShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
    {
        heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));
    }

    [Test]
    public void RemoveMethodShouldWorkCorrectlyAndReturnTrueAfterRemovingTheHero()
    {
        heroRepository.Create(hero);
        bool result = heroRepository.Remove("Hero");

        Assert.True(result);
    }

    [Test]
    public void RemoveMethodShouldWorkCorrectlyAndReturnFalseAfterNoHeroIsFound()
    {
        heroRepository.Create(hero);
        bool result = heroRepository.Remove("Test");

        Assert.False(result);
    }

    [Test]
    public void GetHeroWithHighestLevelMethodShouldWorkCorrectly()
    {
        Hero hero2 = new Hero("Hero2", 50);
        Hero hero3 = new Hero("Hero3", 40);
        Hero hero4 = new Hero("Hero4", 30);
        Hero hero5 = new Hero("Hero5", 20);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        heroRepository.Create(hero5);

        Hero bestHeroLevel = heroRepository.GetHeroWithHighestLevel();

        Assert.That(bestHeroLevel, Is.EqualTo(hero));
    }

    [Test]
    public void GetHero()
    {
        Hero hero2 = new Hero("Hero2", 50);
        Hero hero3 = new Hero("Hero3", 40);
        Hero hero4 = new Hero("Hero4", 30);
        Hero hero5 = new Hero("Hero5", 20);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        heroRepository.Create(hero5);

        Hero heroNeeded = heroRepository.GetHero("Hero");

        Assert.That(heroNeeded, Is.EqualTo(hero));
    }
}