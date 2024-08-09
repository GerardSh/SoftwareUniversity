using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        const double Factor = 0.2;
        const double InitialEngagementRate = 2;

        public BloggerInfluencer(string username, int followers)
            : base(username, followers, InitialEngagementRate, Factor)
        {
        }
    }
}
