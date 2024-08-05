using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        const double GingerPrice = 4;

        public Gingerbread(string name)
            : base(name, GingerPrice)
        {
        }
    }
}
