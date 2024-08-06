using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        List<IMilitaryUnit> army;
        List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double totalAmount = army.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel);

                if (army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
                {
                    totalAmount *= 1.30;
                }

                if (weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    totalAmount *= 1.45;
                }

                return Math.Round(totalAmount, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => army;

        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        public void AddUnit(IMilitaryUnit unit) => army.Add(unit);

        public void AddWeapon(IWeapon weapon) => weapons.Add(weapon);

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {(army.Count > 0 ? string.Join(", ", army.Select(x => x.GetType().Name)) : "No units")}");
            sb.AppendLine($"--Combat equipment: {(weapons.Count > 0 ? string.Join(", ", weapons.Select(x => x.GetType().Name)) : "No weapons")}");
            sb.Append($"--Military Power: {MilitaryPower}");

            return sb.ToString();
        }

        public void Profit(double amount) => Budget += amount;

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy() => army.ForEach(x => x.IncreaseEndurance());
    }
}
