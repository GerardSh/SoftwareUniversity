using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        const double Factor = 0.1;
        const double InitialEngagementRate = 4;

        public FashionInfluencer(string username, int followers)
            : base(username, followers, InitialEngagementRate, Factor)
        {
        }
    }
}
