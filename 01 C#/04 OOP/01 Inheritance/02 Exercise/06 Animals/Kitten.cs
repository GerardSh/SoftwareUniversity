using System;

namespace Animals
{
    public class Kitten : Cat
    {
        const string KittenGender = "Female";

        public Kitten(string name, int age)
            : base(name, age, KittenGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
