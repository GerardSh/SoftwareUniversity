using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        IRepository<IPeak> peaks;
        IRepository<IClimber> climbers;
        IBaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            Peak peak = new Peak(name, elevation, difficultyLevel);

            peaks.Add(peak);

            return string.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));

        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);

            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            IPeak peak = peaks.Get(peakName);

            if (peak == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            if (peak.DifficultyLevel == "Extreme" && climber is NaturalClimber)
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);

            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }

            baseCamp.ArriveAtCamp(climberName);

            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            if (!baseCamp.Residents.Any())
            {
                return "BaseCamp is currently empty.";
            }

            var sb = new StringBuilder();

            sb.AppendLine("BaseCamp residents:");

            foreach (var climber in baseCamp.Residents)
            {
                var currentClimber = climbers.Get(climber);

                sb.AppendLine($"Name: {climber}, Stamina: {currentClimber.Stamina}, Count of Conquered Peaks: {currentClimber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
            }

            IClimber climber = null;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in climbers.All.OrderByDescending(x => x.ConqueredPeaks.Count).ThenBy(x => x.Name))
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> currentPeaks = new List<IPeak>();

                foreach (var peak in peaks.All)
                {
                    if (climber.ConqueredPeaks.Contains(peak.Name))
                    {
                        currentPeaks.Add(peak);
                    }
                }

                foreach (var peak in currentPeaks.OrderByDescending(x => x.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
