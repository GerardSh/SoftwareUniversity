using System;

namespace Animals
{
    public class Tomcat : Cat
    {
        const string TomcatGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, TomcatGender)
        {           
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
