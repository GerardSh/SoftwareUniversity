using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        IRepository<IDiver> divers;
        IRepository<IFish> fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);

            if (diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }

            IFish fish = this.fish.GetModel(fishName);

            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    diver.UpdateHealthStatus();

                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(fish);

                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }
        }

        public string CompetitionStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in divers.Models
                .Where(x => !x.HasHealthIssues)
                .OrderByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.Catch.Count)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver = null;

            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            var sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var fish in diver.Catch)
            {
                IFish currentFish = this.fish.GetModel(fish);

                sb.AppendLine(currentFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int diversWithHealthIssues = divers.Models.Where(x => x.HasHealthIssues).Count();

            foreach (var diver in divers.Models.Where(x => x.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, diversWithHealthIssues);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish = null;

            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (this.fish.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            this.fish.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}