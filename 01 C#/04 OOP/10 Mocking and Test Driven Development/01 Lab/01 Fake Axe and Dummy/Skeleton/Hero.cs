namespace Skeleton
{
    public class Hero
    {
        int experience;
        IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            Name = name;
            this.weapon = weapon;
        }

        public string Name { get; }

        public int Experience => experience;

        public void Attack(ITarget target)
        {
            weapon.Attack(target);

            if (target.IsDead())
            {
                experience += target.GiveExperience();
            }
        }
    }
}
