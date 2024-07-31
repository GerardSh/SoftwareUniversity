using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);

                    if (diver.OxygenLevel == 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fish.Name);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);

                    if (diver.OxygenLevel == 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            diver.Hit(fish);

            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fish.Name);
        }

        public string CompetitionStatistics()
        {
            var sb = new StringBuilder();

            var sortedDivers = divers.Models
                .Where(x => !x.HasHealthIssues)
                .OrderByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.Catch.Count())
                .ThenBy(x => x.Name);

            if (sortedDivers.Any())
            {
                sb.AppendLine("**Nautical-Catch-Challenge**");
            }

            foreach (var diver in sortedDivers)
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
            var sb = new StringBuilder();
            var diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());

            if (diver.Catch.Count > 0)
            {
                sb.AppendLine("Catch Report:");
            }

            foreach (var fishName in diver.Catch)
            {
                IFish currentfish = fish.GetModel(fishName);
                sb.AppendLine(currentfish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            var diversToRecover = divers.Models.Where(x => x.HasHealthIssues).ToList();

            foreach (var diver in diversToRecover)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, diversToRecover.Count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish = null;

            if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
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
