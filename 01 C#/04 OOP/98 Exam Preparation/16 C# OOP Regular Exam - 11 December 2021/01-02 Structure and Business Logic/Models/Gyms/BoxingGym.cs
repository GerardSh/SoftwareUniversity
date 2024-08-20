using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        const int InitialCapacity = 15;

        public BoxingGym(string name)
            : base(name, InitialCapacity)
        {
        }
    }
}
