using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Heroes
{
    public class Mace : Weapon
    {
        const int Damage = 25;

        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (Durability > 0)
            {
                Durability--;

                return Damage;
            }

            return 0;
        }
    }
}
