using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        const double Factor = 0.15;
        const double InitialEngagementRate = 3;

        public BusinessInfluencer(string username, int followers)
            : base(username, followers, InitialEngagementRate, Factor)
        {
        }
    }
}
