using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => models;

        public void AddModel(IPlayer model) => models.Add(model);

        public bool ExistsModel(string name) => GetModel(name) == null? false: true;

        public IPlayer GetModel(string name) => models.FirstOrDefault(x=>x.Name == name);

        public bool RemoveModel(string name) => models.Remove(GetModel(name));
    }
}
