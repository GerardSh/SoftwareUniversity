using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models;

        public void AddItem(IPlanet model) => models.Add(model);

        public IPlanet FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => models.Remove(FindByName(name));
    }
}
