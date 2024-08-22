using TicTacToe;
using TicTacToe.Players;

public class TicTacToeGame
{
    public TicTacToeGame(IPlayer firstPlayer, IPlayer secondPlayer)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        WinnerLogic = new GameWinnerLogic();
    }
    public IPlayer FirstPlayer { get; }

    public IPlayer SecondPlayer { get; }

    GameWinnerLogic WinnerLogic { get; }

    public GameResult Play()
    {
        Board board = new Board();
        IPlayer currentPlayer = FirstPlayer;
        Symbol symbol = Symbol.X;

        while (!WinnerLogic.IsGameOver(board))
        {
            var move = currentPlayer.Play(board, symbol);
            board.PlaceSymbol(move, symbol);

            if (currentPlayer == FirstPlayer)
            {
                currentPlayer = SecondPlayer;
                symbol = Symbol.O;
            }
            else
            {
                currentPlayer = FirstPlayer;
                symbol = Symbol.X;
            }
        }

        var winner = WinnerLogic.GetWinner(board);

        return new GameResult(winner, board);
    }

    private Symbol IsRowFull(Board board, int row)
    {
        throw new NotImplementedException();
    }
}
