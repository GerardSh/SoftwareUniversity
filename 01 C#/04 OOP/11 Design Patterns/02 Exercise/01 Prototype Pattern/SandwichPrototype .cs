namespace Prototype
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();

        public abstract SandwichPrototype DeepCopy();
    }
}
