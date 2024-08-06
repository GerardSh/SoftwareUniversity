using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        const double Cost = 11;

        public SpaceForces()
            : base(Cost)
        {
        }
    }
}
