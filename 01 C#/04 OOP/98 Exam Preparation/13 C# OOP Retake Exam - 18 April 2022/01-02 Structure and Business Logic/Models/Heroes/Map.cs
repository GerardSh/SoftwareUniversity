using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Heroes
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians = players.Where(x => x.GetType().Name == nameof(Barbarian)).ToList();

            int knightDeaths = 0;
            int barbarianDeaths = 0;

            while (knights.Count > 0 && barbarians.Count > 0)
            {
                foreach (var knight in knights)
                {
                    if (!knight.IsAlive)
                    {
                        continue;
                    }

                    foreach (var barbarian in barbarians)
                    {
                        if (knight.Weapon != null && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());

                            if (!barbarian.IsAlive)
                            {
                                barbarianDeaths++;
                            }
                        }
                    }
                }

                barbarians = barbarians.Where(x=>x.IsAlive).ToList();

                foreach (var barbarian in barbarians)
                {
                    if (!barbarian.IsAlive)
                    {
                        continue;
                    }

                    foreach (var knight in knights)
                    {
                        if (barbarian.Weapon != null && knight.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }

                        if (!knight.IsAlive)
                        {
                            knightDeaths++;
                        }
                    }
                }

                knights = knights.Where(x => x.IsAlive).ToList();
            }

            if (knights.Count > 0)
            {
                return string.Format(OutputMessages.MapFightKnightsWin, knightDeaths);
            }

            return string.Format(OutputMessages.MapFigthBarbariansWin, barbarianDeaths);
        }
    }
}
