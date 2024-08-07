using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        List<IHero> models;

        public HeroRepository()
        {
           models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => models;

        public void Add(IHero model) => models.Add(model);

        public IHero FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IHero model) => models.Remove(model);
    }
}
