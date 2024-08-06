using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        FootballPlayer player;
        FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("name", 10, "Forward");
            team = new FootballTeam("name", 20);
        }

        [Test]
        public void FootballPlayerConstructorShouldWorkCorrectlyAndThrowExceptionWhenWrongDataIsGiven()
        {
            Assert.Throws<ArgumentException>(() => new FootballPlayer("", 10, "Forward"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer(null, 10, "Forward"));

            Assert.Throws<ArgumentException>(() => new FootballPlayer("name", 0, "Forward"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer("name", 22, "Forward"));

            Assert.Throws<ArgumentException>(() => new FootballPlayer("name", 10, ""));

            Assert.NotNull(player);
            Assert.That(player.Name, Is.EqualTo("name"));
            Assert.That(player.PlayerNumber, Is.EqualTo(10));
            Assert.That(player.Position, Is.EqualTo("Forward"));
            Assert.That(player.ScoredGoals, Is.EqualTo(0));

            player.Score();

            Assert.That(player.ScoredGoals, Is.EqualTo(1));
        }

        [Test]
        public void FootballTeamConstructorShouldWorkCorrectlyAndThrowExceptionsWhenWrongDataIsGiven()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("", 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));

            Assert.Throws<ArgumentException>(() => new FootballTeam("name", 14));

            Assert.That(team.Players, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("name"));
            Assert.That(team.Capacity, Is.EqualTo(20));
            Assert.That(team.Players.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddNewPlayerMethodShouldWorkCorrectly()
        {
            string result = team.AddNewPlayer(player);

            Assert.That(result, Is.EqualTo($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}"));
            Assert.That(team.Players.Count, Is.EqualTo(1));

            team.Capacity = 15;

            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player);

            result = team.AddNewPlayer(player);

            Assert.That(result, Is.EqualTo("No more positions available!"));
            Assert.That(team.Players.Count, Is.EqualTo(15));
        }

        [Test]
        public void PickPlayerMethodShouldReturnCorrectResult()
        {
            team.AddNewPlayer(player);
            team.AddNewPlayer(new FootballPlayer("name2", 20, "Goalkeeper"));

            FootballPlayer returnedPlayer = team.PickPlayer("name");

            Assert.That(returnedPlayer, Is.EqualTo(player));

            returnedPlayer = team.PickPlayer("name3");

            Assert.IsNull(returnedPlayer);
        }

        [Test]
        public void PlayerScoreMethodShouldReturnCorrectInformation()
        {
            team.AddNewPlayer(player);

            string result = team.PlayerScore(player.PlayerNumber);

            Assert.That(result, Is.EqualTo("name scored and now has 1 for this season!"));
        }
    }
}