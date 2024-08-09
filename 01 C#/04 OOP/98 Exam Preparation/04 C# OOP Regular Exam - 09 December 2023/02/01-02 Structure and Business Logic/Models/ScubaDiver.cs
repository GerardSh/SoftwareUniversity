using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        const int InitialOxygenLevel = 540;

        public ScubaDiver(string name)
            : base(name, InitialOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.30);
        }

        public override void RenewOxy() => OxygenLevel = InitialOxygenLevel;
    }
}
