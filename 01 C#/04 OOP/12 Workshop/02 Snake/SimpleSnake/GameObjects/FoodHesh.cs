using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class FoodHesh : Food
    {
        const char symbol = '#';
        const int points = 3;

        public FoodHesh(Wall wall)
            : base(wall, symbol, points)
        {
        }
    }
}
