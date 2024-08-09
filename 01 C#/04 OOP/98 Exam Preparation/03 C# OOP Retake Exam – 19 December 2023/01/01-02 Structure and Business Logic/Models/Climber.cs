using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;

            conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                stamina = value;

                if (stamina < 0)
                {
                    stamina = 0;
                }
                
                if (stamina > 10)
                {
                    stamina = 10;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            string stringToReturn = $"{GetType().Name} - Name: {Name}, Stamina: {Stamina}{Environment.NewLine}Peaks conquered: {(conqueredPeaks.Any() ? conqueredPeaks.Count : "no peaks conquered")}";

            return stringToReturn;
        }
    }
}
