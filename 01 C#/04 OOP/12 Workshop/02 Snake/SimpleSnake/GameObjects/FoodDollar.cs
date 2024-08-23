using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        const char symbol = '$';
        const int points = 2;

        public FoodDollar(Wall wall)
            : base(wall, symbol, points)
        {
        }
    }
}
