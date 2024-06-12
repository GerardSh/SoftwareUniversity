namespace Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public int Power { get; }

        public string Name { get; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name}";          
        }
    }
}
