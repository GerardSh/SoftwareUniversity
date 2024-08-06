using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        const double Cost = 30;

        public AnonymousImpactUnit()
            : base(Cost)
        {
        }
    }
}
