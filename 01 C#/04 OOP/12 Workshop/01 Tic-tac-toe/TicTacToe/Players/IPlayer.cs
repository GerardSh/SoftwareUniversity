using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        Index Play(Board board, Symbol symbol);
    }
}
