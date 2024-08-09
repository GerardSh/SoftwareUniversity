using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        SortedSet<string> residents;

        public BaseCamp()
        {
            residents = new SortedSet<string>();
        }

        public IReadOnlyCollection<string> Residents => residents;

        public void ArriveAtCamp(string climberName) => residents.Add(climberName);

        public void LeaveCamp(string climberName) => residents.Remove(climberName);
    }
}
