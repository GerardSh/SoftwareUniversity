using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => models;

        public void Add(IEquipment model) => models.Add(model);

        public IEquipment FindByType(string type) => models.FirstOrDefault(x=>x.GetType().Name == type);

        public bool Remove(IEquipment model) => models.Remove(model);
    }
}
