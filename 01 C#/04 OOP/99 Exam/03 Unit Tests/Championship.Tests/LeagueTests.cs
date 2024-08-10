using System;
using NUnit.Framework;

namespace Championship.Tests
{
    public class LeagueTests
    {
        Team team;
        League league;

        [SetUp]
        public void Setup()
        {
            team = new Team("name");
            league = new League();
        }

        [Test]
        public void TeamConstructorShouldCreateObjectCorrectly()
        {
            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("name"));
            Assert.That(team.Wins, Is.EqualTo(0));
            Assert.That(team.Draws, Is.EqualTo(0));
            Assert.That(team.Loses, Is.EqualTo(0));

            Assert.That("name - 0 points (0W 0D 0L)", Is.EqualTo(team.ToString()));

            team.Win();
            Assert.That(team.Wins, Is.EqualTo(1));

            team.Draw();
            Assert.That(team.Draws, Is.EqualTo(1));

            team.Lose();
            Assert.That(team.Loses, Is.EqualTo(1));
            Assert.That("name - 4 points (1W 1D 1L)", Is.EqualTo(team.ToString()));
        }

        [Test]
        public void LegueConstructorShouldCreateObjectCorrectly()
        {
            Assert.That(league, Is.Not.Null);
            Assert.That(league.Capacity, Is.EqualTo(10));
            Assert.That(league.Teams, Is.Not.Null);
            Assert.That(league.Teams.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddTeamMethodShouldWorkCorrectly()
        {
            Team team2 = new Team("name2");
            Team team3 = new Team("name3");
            Team team4 = new Team("name4");
            Team team5 = new Team("name5");
            Team team6 = new Team("name6");
            Team team7 = new Team("name7");
            Team team8 = new Team("name8");
            Team team9 = new Team("name9");
            Team team10 = new Team("name10");

            Assert.That(league.Teams.Count, Is.EqualTo(0));

            league.AddTeam(team);

            Assert.That(league.Teams.Count, Is.EqualTo(1));

            league.AddTeam(team2);

            Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("name2")));

            Assert.That(league.Teams.Count, Is.EqualTo(2));

            league.AddTeam(team3);
            league.AddTeam(team4);
            league.AddTeam(team5);
            league.AddTeam(team6);
            league.AddTeam(team7);
            league.AddTeam(team8);
            league.AddTeam(team9);
            league.AddTeam(team10);

            Assert.That(league.Teams.Count, Is.EqualTo(10));
            Assert.That(league.Teams.Count, Is.EqualTo(league.Capacity));

            Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("name11")));

            Assert.That(league.Teams.Count, Is.EqualTo(10));
            Assert.That(league.Teams.Count, Is.EqualTo(league.Capacity));
        }

        [Test]
        public void RemoveTeamMethodShouldWorkCorrectly()
        {
            Team team2 = new Team("name2");
            Team team3 = new Team("name3");

            league.AddTeam(team);
            league.AddTeam(team2);
            league.AddTeam(team3);

            Assert.That(league.Teams.Count, Is.EqualTo(3));

            bool result = league.RemoveTeam("name4");

            Assert.False(result);
            Assert.That(league.Teams.Count, Is.EqualTo(3));

            result = league.RemoveTeam("name2");

            Assert.True(result);
            Assert.That(league.Teams.Count, Is.EqualTo(2));
        }

        [Test]
        public void PlayMatchMethodShouldWorkCorrectly()
        {
            Team team2 = new Team("name2");
            Team team3 = new Team("name3");

            league.AddTeam(team);
            league.AddTeam(team2);
            league.AddTeam(team3);

            Assert.Throws<InvalidOperationException>(() => league.PlayMatch("name2", null, 1, 3));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(null, null, 1, 3));
            Assert.Throws<InvalidOperationException>(() => league.PlayMatch(null, "name2", 1, 3));

            Assert.That(team2.Wins, Is.EqualTo(0));
            Assert.That(team2.Loses, Is.EqualTo(0));
            Assert.That(team2.Draws, Is.EqualTo(0));

            Assert.That(team3.Wins, Is.EqualTo(0));
            Assert.That(team3.Loses, Is.EqualTo(0));
            Assert.That(team3.Draws, Is.EqualTo(0));

            league.PlayMatch("name2", "name3", 1, 2);

            Assert.That(team2.Wins, Is.EqualTo(0));
            Assert.That(team2.Loses, Is.EqualTo(1));
            Assert.That(team2.Draws, Is.EqualTo(0));

            Assert.That(team3.Wins, Is.EqualTo(1));
            Assert.That(team3.Loses, Is.EqualTo(0));
            Assert.That(team3.Draws, Is.EqualTo(0));

            league.PlayMatch("name2", "name3", 1, 1);

            Assert.That(team2.Wins, Is.EqualTo(0));
            Assert.That(team2.Loses, Is.EqualTo(1));
            Assert.That(team2.Draws, Is.EqualTo(1));

            Assert.That(team3.Wins, Is.EqualTo(1));
            Assert.That(team3.Loses, Is.EqualTo(0));
            Assert.That(team3.Draws, Is.EqualTo(1));

            league.PlayMatch("name2", "name3", 2, 1);

            Assert.That(team2.Wins, Is.EqualTo(1));
            Assert.That(team2.Loses, Is.EqualTo(1));
            Assert.That(team2.Draws, Is.EqualTo(1));

            Assert.That(team3.Wins, Is.EqualTo(1));
            Assert.That(team3.Loses, Is.EqualTo(1));
            Assert.That(team3.Draws, Is.EqualTo(1));
        }

        [Test]
        public void GetTeamInfoMethodShouldWorkCorrectly()
        {
            Team team2 = new Team("name2");
            Team team3 = new Team("name3");

            league.AddTeam(team2);
            league.AddTeam(team3);

            Assert.Throws<InvalidOperationException>(() => league.GetTeamInfo("name"));

            string result = league.GetTeamInfo("name2");

            Assert.That("name2 - 0 points (0W 0D 0L)", Is.EqualTo(team2.ToString()));
            Assert.That(result, Is.EqualTo("name2 - 0 points (0W 0D 0L)"));
        }
    }
}