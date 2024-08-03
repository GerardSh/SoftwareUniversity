using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        const int CurrentBatteryCapacity = 20000;
        const int CurrentConvertionCapacityIndex = 2000;

        public DomesticAssistant(string model)
            : base(model, CurrentBatteryCapacity, CurrentConvertionCapacityIndex)
        {
        }
    }
}
