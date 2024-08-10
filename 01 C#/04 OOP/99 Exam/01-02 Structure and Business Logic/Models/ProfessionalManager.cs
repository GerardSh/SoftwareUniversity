using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        const double InitialRanking = 60;

        public ProfessionalManager(string name)
            : base(name, InitialRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            double result = updateValue * 1.5;

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
