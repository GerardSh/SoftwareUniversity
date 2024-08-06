using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        const double Price = 8.75;

        public SpaceMissiles(int destructionLevel)
            : base(Price, destructionLevel)
        {
        }
    }
}
