using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }

                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }

                weapon = value;
            }
        }

        public bool IsAlive => health > 0;

        public void AddWeapon(IWeapon weapon) => Weapon = weapon;

        public void TakeDamage(int points)
        {
            int resultArmour = Armour - points;

            if (resultArmour >= 0)
            {
                Armour = resultArmour;
            }
            else
            {
                Armour = 0;

               int resultHealth = Health - Math.Abs(resultArmour);

                if (resultHealth >= 0)
                {
                    Health = resultHealth;
                }
                else
                {
                    Health = 0;
                }
            }
        }
    }
}
