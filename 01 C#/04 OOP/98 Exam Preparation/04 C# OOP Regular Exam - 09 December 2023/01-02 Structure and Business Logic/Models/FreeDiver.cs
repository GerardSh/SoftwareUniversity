using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        const int OxygenLevelStartingValue = 120;

        public FreeDiver(string name)
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
