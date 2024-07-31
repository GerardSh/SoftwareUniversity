using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        List<ITeam> models;

        public TeamRepository()
        {
            models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => models;

        public void AddModel(ITeam model) => models.Add(model);

        public bool ExistsModel(string name) => GetModel(name) == null ? false : true;

        public ITeam GetModel(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool RemoveModel(string name) => models.Remove(GetModel(name));
    }
}
