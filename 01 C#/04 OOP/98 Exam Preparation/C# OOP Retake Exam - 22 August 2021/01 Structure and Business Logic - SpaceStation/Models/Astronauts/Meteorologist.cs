using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) 
            : base(name, 90)
        {
        }
    }
}
