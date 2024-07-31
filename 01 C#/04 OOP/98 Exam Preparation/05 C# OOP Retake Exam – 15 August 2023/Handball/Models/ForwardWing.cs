using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        const double InitialRating = 5.5;

        public ForwardWing(string name)
            : base(name, InitialRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 0.75;

            if (Rating < 1)
            {
                Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += 1.25;

            if (Rating > 10)
            {
                Rating = 10;
            }
        }
    }
}
