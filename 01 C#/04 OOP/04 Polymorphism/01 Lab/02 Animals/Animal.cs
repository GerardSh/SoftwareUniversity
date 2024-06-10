namespace Animals
{
    public abstract class Animal
    {
        protected string name;

        protected string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf() => $"I am {name} and my fovourite food is {favouriteFood}";
    }
}
