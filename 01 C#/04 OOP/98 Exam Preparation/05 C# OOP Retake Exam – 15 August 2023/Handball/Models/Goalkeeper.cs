using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        const double InitialRating = 2.5;

        public Goalkeeper(string name)
            : base(name, InitialRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 1.25;

            if (Rating < 1)
            {
                Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += 0.75;

            if (Rating > 10)
            {
                Rating = 10;
            }
        }
    }
}
