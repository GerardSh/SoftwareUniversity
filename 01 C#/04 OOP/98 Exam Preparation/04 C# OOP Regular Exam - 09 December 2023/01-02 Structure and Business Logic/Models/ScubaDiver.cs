using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        const int OxygenLevelStartingValue = 540;

        public ScubaDiver(string name)
            : base(name, OxygenLevelStartingValue)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double newLevel = TimeToCatch * 0.60;

            OxygenLevel -= (int)Math.Round(newLevel, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = OxygenLevelStartingValue;
        }
    }
}
