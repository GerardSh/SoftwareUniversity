namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
