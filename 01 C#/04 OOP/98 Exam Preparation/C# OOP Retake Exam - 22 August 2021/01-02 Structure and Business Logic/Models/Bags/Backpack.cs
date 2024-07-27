using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            Items = new List<string>();
        }

        public ICollection<string> Items { get; }
    }
}
