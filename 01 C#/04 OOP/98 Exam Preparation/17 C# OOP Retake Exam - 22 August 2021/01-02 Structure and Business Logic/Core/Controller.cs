using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepo;
        private readonly IRepository<IPlanet> planetRepo;
        int planetMissions = 0;


        public Controller()
        {
            astronautRepo = new AstronautRepository();
            planetRepo = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronautRepo.Add(astronaut);

            string result = string.Format(OutputMessages.AstronautAdded, type, astronautName);

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepo.Add(planet);

            string result = string.Format(OutputMessages.PlanetAdded, planetName);

            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> list = astronautRepo.Models.Where(x => x.Oxygen > 60).ToList();

            if (list.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();

            var planet = planetRepo.Models.FirstOrDefault(x => x.Name == planetName);

            mission.Explore(planet, list);

            int lostAstronauts = list.Count(x => x.Oxygen == 0);

            string message = string.Format(OutputMessages.PlanetExplored, planetName, lostAstronauts);
            planetMissions++;

            return message;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{planetMissions} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronautRepo.FindByName(astronautName);
            string message = null;

            if (!astronautRepo.Remove(astronaut))
            {
                message = string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName);

                throw new InvalidOperationException(message);
            }

            message = string.Format(OutputMessages.AstronautRetired, astronautName);

            return message;

        }
    }
}
