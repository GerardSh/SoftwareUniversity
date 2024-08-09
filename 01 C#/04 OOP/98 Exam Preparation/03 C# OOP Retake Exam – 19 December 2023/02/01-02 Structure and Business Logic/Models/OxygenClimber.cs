using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        const int InitialStamina = 10;

        public OxygenClimber(string name)
            : base(name, InitialStamina)
        {
        }

        public override void Rest(int daysCount) => Stamina += daysCount;
    }
}
