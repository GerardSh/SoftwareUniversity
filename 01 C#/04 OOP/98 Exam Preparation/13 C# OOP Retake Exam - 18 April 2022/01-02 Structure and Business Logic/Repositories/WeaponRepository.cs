using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Repositories
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models;

        public void Add(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool Remove(IWeapon model) => models.Remove(model);
    }
}
