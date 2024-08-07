using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Heroes
{
    public class Knight : Hero
    {
        public Knight(string name, int health, int armour)
            : base(name, health, armour)
        {
        }
    }
}
