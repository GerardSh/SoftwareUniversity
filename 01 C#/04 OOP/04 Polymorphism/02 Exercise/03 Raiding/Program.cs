namespace Raiding
{
    public class Program
    {
        public static void Main()
        {
            const int DruidAndRoguePower = 80;
            const int PaladinAndWarriorPower = 100;

            int n = int.Parse(Console.ReadLine());

            var raidGroup = new List<BaseHero>(n);

            while (raidGroup.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = null;

                if (heroType == "Druid")
                {
                    hero = new Druid(heroName, DruidAndRoguePower);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName, PaladinAndWarriorPower);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName, DruidAndRoguePower);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName, PaladinAndWarriorPower);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            for (int i = 0; i < raidGroup.Count; i++)
            {
                Console.WriteLine(raidGroup[i].CastAbility());
            }

            if (raidGroup.Sum(x => x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}