using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        const double InitialRanking = 30;

        public SeniorManager(string name)
            : base(name, InitialRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            Ranking += updateValue;

            if (Ranking < 0)
            {
                Ranking = 0;
            }
            else if (Ranking > 100)
            {
                Ranking = 100;
            }
        }
    }
}
