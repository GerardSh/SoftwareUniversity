using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class PeakRepository : IRepository<IPeak>
    {
        List<IPeak> all;

        public PeakRepository()
        {
            all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => all;

        public void Add(IPeak model) => all.Add(model);

        public IPeak Get(string name) => all.FirstOrDefault(x => x.Name == name);
    }
}
