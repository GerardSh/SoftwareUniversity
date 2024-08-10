using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class TeamRepository : IRepository<ITeam>
    {
        List<ITeam> models;

        public TeamRepository()
        {
            models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => models;

        public int Capacity => 10;

        public void Add(ITeam model)
        {
            if (models.Count == Capacity)
            {
                return;
            }

            models.Add(model);
        }

        public bool Exists(string name) => models.Any(x=> x.Name == name);

        public ITeam Get(string name) => models.FirstOrDefault(x=>x.Name == name);

        public bool Remove(string name) => models.Remove(Get(name));
    }
}
