using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        const int InitialOxygenLevel = 120;

        public FreeDiver(string name)
            : base(name, InitialOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.60);
        }

        public override void RenewOxy() => OxygenLevel = InitialOxygenLevel;
    }
}
