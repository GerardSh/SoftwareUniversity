using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        const char symbol = '*';
        const int points = 1;

        public FoodAsterisk(Wall wall)
            : base(wall, symbol, points)
        {
        }
    }
}
