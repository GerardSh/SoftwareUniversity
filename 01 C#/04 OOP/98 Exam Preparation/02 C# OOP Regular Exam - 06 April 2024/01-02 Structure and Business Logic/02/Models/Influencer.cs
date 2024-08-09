using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        List<string> participations;
        double factor;

        protected Influencer(string username, int followers, double engagementRate, double factor)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            participations = new List<string>();
            this.factor = factor;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }

                username = value;
            }
        }

        public int Followers
        {
            get => followers; 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }

                followers = value;
            }
        }

        public double EngagementRate { get; private set; }

        public double Income { get; private set; }

        public IReadOnlyCollection<string> Participations => participations;

        public int CalculateCampaignPrice() => (int)(Followers * EngagementRate * factor);

        public void EarnFee(double amount) => Income += amount;

        public void EndParticipation(string brand) => participations.Remove(brand);

        public void EnrollCampaign(string brand) => participations.Add(brand);

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
