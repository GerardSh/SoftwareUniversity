using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        List<string> @catch;
        private string name;
        private int oxygenLevel;
        private double competitionPoints;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            @catch = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => @catch;

        public double CompetitionPoints { get => Math.Round(competitionPoints,1); private set => competitionPoints = value; }

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            @catch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus() => HasHealthIssues = !HasHealthIssues;

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {@catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
