using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Pattern
{
    public abstract class Bread
    {
        public abstract void Bake();

        public abstract void MixIndgridients();

        void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public void Make()
        {
            MixIndgridients();
            Bake();
            Slice();
        }
    }
}
