using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        IRepository<IInfluencer> influencers;
        IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            var sb = new StringBuilder();

            var sortedInfluencers = influencers.Models.OrderByDescending(x => x.Income).ThenByDescending(x => x.Followers);

            foreach (var influencer in sortedInfluencers)
            {
                sb.AppendLine(influencer.ToString());

                if (!influencer.Participations.Any())
                {
                    continue;
                }

                sb.AppendLine("Active Campaigns:");

                foreach (var brand in influencer.Participations.OrderBy(x => x))
                {
                    var campaign = campaigns.FindByName(brand);

                    sb.AppendLine($"--{campaign.ToString()}");
                }
            }

            return sb.ToString().Trim();
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaign.Contributors.FirstOrDefault(x => x == username) != null)
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            string campaignType = campaign.GetType().Name;
            string influencerType = influencer.GetType().Name;

            if (influencerType == nameof(BloggerInfluencer) && campaignType == nameof(ProductCampaign)
                || influencerType == nameof(FashionInfluencer) && campaignType == nameof(ServiceCampaign))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            int calculatedPrice = influencer.CalculateCampaignPrice();

            if (campaign.Budget < calculatedPrice)
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EarnFee(calculatedPrice);

            influencer.EnrollCampaign(brand);

            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign campaign = null;

            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand);
            }
            else if (typeName == nameof(ServiceCampaign))
            {
                campaign = new ServiceCampaign(brand);
            }
            else
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            campaigns.AddModel(campaign);

            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return OutputMessages.InvalidCampaignToClose;
            }

            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencer in influencers.Models.Where(x => x.Participations.Contains(brand)))
            {
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);

            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Any())
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);

            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            var campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return OutputMessages.InvalidCampaignToFund;
            }

            if (amount <= 0)
            {
                return OutputMessages.NotPositiveFundingAmount;
            }

            campaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer influencer = null;

            if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}
