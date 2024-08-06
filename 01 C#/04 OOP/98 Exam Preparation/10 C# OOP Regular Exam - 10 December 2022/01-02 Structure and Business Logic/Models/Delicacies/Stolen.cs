using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        const double StolenPrice = 3.5;

        public Stolen(string name)
            : base(name, StolenPrice)
        {
        }
    }
}
