using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingridients: {GetIngridients()}");

            return MemberwiseClone() as SandwichPrototype;
        }

        public override SandwichPrototype DeepCopy()
        {
            Console.WriteLine($"Cloning sandwich with ingridients: {GetIngridients()}");

            string bread = new string(this.bread);
            string meat = new string(this.meat);
            string cheese = new string(this.cheese);
            string veggies = new string(this.veggies);

            return new Sandwich(bread, meat, cheese, veggies);
        }

        private string GetIngridients() => $"{bread}, {meat}, {cheese}, {veggies}";
    }
}
