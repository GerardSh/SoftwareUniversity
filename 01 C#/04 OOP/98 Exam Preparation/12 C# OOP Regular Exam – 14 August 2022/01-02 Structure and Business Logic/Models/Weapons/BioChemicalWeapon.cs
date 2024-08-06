using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        const double Price = 3.2;

        public BioChemicalWeapon(int destructionLevel)
            : base(Price, destructionLevel)
        {
        }
    }
}
