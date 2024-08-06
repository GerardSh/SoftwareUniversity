using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        const double Cost = 2.5;

        public StormTroopers()
            : base(Cost)
        {
        }
    }
}
