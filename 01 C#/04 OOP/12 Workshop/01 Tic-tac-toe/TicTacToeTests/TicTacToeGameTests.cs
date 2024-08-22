using Moq;
using TicTacToe;
using TicTacToe.Players;

namespace TicTacToeTests
{
    public class TicTacToeGameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlayShouldReturnValue()
        {
            var player = new Mock<IPlayer>();

            player.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board x, Symbol s) =>
                {
                    return x.GetEmptyPositions().First();
                });

            var game = new TicTacToeGame(player.Object, player.Object);
        }

        [Test]
        public void PlayShouldReturnCorrectWinner()
        {
            var player1CurrentCol = 0;
            var player2CurrentCol = 0;

            var player1 = new Mock<IPlayer>();

            player1.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
              .Returns((Board x, Symbol s) => new Index(0, player1CurrentCol++));

            var player2 = new Mock<IPlayer>();
            player2.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                  .Returns((Board x, Symbol s) => new Index(1, player2CurrentCol++));

            var game = new TicTacToeGame(player1.Object, player2.Object);
            var winner = game.Play();

            Assert.That(winner.Winner, Is.EqualTo(Symbol.X));
        }

        [Test]
        public void RandomAndAIPlayersShouldNeverWinAgainstAIPlayer()
        {
            Simulation simulation = new Simulation();

            int[] results = simulation.Simulate(new AiPlayer(), new RandomPlayer(), 10);

            Assert.That(results[1], Is.EqualTo(0));
            Assert.That(results[0], Is.GreaterThan(0));

            results = simulation.Simulate(new RandomPlayer(), new AiPlayer(), 10);

            Assert.That(results[0], Is.EqualTo(0));
            Assert.That(results[1], Is.GreaterThan(0));

            results = simulation.Simulate(new AiPlayer(), new AiPlayer(), 10);

            Assert.That(results[0], Is.EqualTo(0));
            Assert.That(results[1], Is.EqualTo(0));
        }
    }
}