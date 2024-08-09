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
        HashSet<string> conqueredPeaks;
        private string name;
        private int stamina;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new HashSet<string>();
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
                if (value > 10)
                {
                    value = 10;
                }

                if (value < 0)
                {
                    value = 0;
                }

                stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            conqueredPeaks.Add(peak.Name);

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
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.AppendLine($"Peaks conquered: {(ConqueredPeaks.Count > 0 ? ConqueredPeaks.Count : "no peaks conquered")}");

            return sb.ToString().Trim();
        }
    }
}
