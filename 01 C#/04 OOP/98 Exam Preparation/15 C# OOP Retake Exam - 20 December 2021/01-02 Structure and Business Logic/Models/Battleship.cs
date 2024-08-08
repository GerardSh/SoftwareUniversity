using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        const int ArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, ArmorThickness)
        {
        }

       public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
            else
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
        }

        public override void RepairVessel() => base.ArmorThickness = ArmorThickness;

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine+ $" *Sonar mode: {(SonarMode? "ON":"OFF")}";
        }
    }
}
