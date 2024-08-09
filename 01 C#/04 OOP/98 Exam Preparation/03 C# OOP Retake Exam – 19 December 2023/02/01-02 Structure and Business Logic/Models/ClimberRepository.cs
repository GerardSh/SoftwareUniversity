using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class ClimberRepository : IRepository<IClimber>
    {
        List<IClimber> all;

        public ClimberRepository()
        {
            all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => all;

        public void Add(IClimber model) => all.Add(model);

        public IClimber Get(string name) => all.FirstOrDefault(x => x.Name == name);
    }
}
