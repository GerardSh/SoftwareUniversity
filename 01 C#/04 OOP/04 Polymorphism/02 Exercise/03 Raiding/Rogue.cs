namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
