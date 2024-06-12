namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}
