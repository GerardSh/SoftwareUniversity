using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        const double Price = 13.5;

        public MulledWine(string name, string size)
            : base(name, size, Price)
        {
        }
    }
}
