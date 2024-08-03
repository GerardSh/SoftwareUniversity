using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        const int InitialInterfaceStandard = 10045;
        const int InitialBatteryUsage = 10000;

        public SpecializedArm() : base(InitialInterfaceStandard, InitialBatteryUsage)
        {
        }
    }
}
