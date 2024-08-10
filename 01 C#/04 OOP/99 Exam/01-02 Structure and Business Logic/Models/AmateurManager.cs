using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        const double InitialRanking = 15;

        public AmateurManager(string name)
            : base(name, InitialRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            double result = updateValue * 0.75;

            Ranking += result;

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
