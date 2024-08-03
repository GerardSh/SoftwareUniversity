using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        List<ISupplement> models;

        public SupplementRepository()
        {
           models = new List<ISupplement>();
        }

        public void AddNew(ISupplement model) => models.Add(model);

        public ISupplement FindByStandard(int interfaceStandard) => 
            models.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models() => models;

        public bool RemoveByName(string typeName) => models.Remove(models.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
