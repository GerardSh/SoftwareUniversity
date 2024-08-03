using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        const int InitialInterfaceStandard = 20082;
        const int InitialBatteryUsage = 5000;

        public LaserRadar() : base(InitialInterfaceStandard, InitialBatteryUsage)
        {
        }
    }
}
