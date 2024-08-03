using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        const int CurrentBatteryCapacity = 40000;
        const int CurrentConvertionCapacityIndex = 5000;

        public IndustrialAssistant(string model)
            : base(model, CurrentBatteryCapacity, CurrentConvertionCapacityIndex)
        {
        }
    }
}
