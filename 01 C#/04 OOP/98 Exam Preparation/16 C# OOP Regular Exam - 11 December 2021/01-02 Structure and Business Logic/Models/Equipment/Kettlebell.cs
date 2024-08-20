using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        const double InitialWeights = 10000;
        const decimal InitialPrice = 80;

        public Kettlebell()
            : base(InitialWeights, InitialPrice)
        {
        }
    }
}
