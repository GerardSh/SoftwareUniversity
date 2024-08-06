using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);

            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attackingPlanet = planets.FindByName(planetOne);
            IPlanet defendingPlanet = planets.FindByName(planetTwo);

            IPlanet planetWon = null;
            IPlanet planetLost = null;

            if (attackingPlanet.MilitaryPower > defendingPlanet.MilitaryPower)
            {
                planetWon = attackingPlanet;
                planetLost = defendingPlanet;
            }
            else if (attackingPlanet.MilitaryPower < defendingPlanet.MilitaryPower)
            {
                planetWon = defendingPlanet;
                planetLost = attackingPlanet;
            }
            else
            {
                bool attackingPlanetHasNuclear = attackingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));
                bool defendingPlanetHasNuclear = defendingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));

                if (attackingPlanetHasNuclear && !defendingPlanetHasNuclear)
                {
                    planetWon = attackingPlanet;
                    planetLost = defendingPlanet;
                }
                else if (!attackingPlanetHasNuclear && defendingPlanetHasNuclear)
                {
                    planetWon = defendingPlanet;
                    planetLost = attackingPlanet;
                }
                else
                {
                    attackingPlanet.Spend(attackingPlanet.Budget / 2);
                    defendingPlanet.Spend(defendingPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            planetWon.Spend(planetWon.Budget / 2);
            planetWon.Profit(planetLost.Budget / 2);
            planetWon.Profit(planetLost.Army.Sum(x => x.Cost) + planetLost.Weapons.Sum(x => x.Price));

            planets.RemoveItem(planetLost.Name);

            return string.Format(OutputMessages.WinnigTheWar, planetWon.Name, planetLost.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.TrainArmy();
            planet.Spend(1.25);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}