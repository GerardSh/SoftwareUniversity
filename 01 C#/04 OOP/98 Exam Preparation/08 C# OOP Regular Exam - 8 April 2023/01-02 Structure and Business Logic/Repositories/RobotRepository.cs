using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public void AddNew(IRobot model) => models.Add(model);

        public IRobot FindByStandard(int interfaceStandard) =>
            models.FirstOrDefault(x => x.InterfaceStandards.Any(x => x == interfaceStandard));

        public IReadOnlyCollection<IRobot> Models() => models;

        public bool RemoveByName(string typeName) => models.Remove(models.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
