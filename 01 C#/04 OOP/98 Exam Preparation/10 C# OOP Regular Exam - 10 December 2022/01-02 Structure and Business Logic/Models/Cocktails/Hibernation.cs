using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Models.Cocktails
{
   
    public class Hibernation : Cocktail
    {
        const double Price = 10.5;

        public Hibernation(string name, string size)
            : base(name, size, Price)
        {
        }
    }
}
