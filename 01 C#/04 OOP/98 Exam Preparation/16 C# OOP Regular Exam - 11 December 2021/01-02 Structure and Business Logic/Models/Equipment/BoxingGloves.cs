using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        const double InitialWeights = 227;
        const decimal InitialPrice = 120;

        public BoxingGloves()
            : base(InitialWeights, InitialPrice)
        {
        }
    }
}
