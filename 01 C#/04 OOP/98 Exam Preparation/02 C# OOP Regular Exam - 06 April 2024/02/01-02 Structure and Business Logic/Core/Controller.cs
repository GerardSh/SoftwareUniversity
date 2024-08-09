using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Text;

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

            foreach (var influencer in influencers.Models.OrderByDescending(x => x.Income).ThenByDescending(x => x.Followers))
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Any())
                {
                    sb.AppendLine("Active Campaigns:");

                    foreach (var campaign in influencer.Participations.ToList().OrderBy(x => x))
                    {
                        sb.AppendLine(campaigns.FindByName(campaign).ToString());
                    }
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

            if (campaign.Contributors.Contains(influencer.Username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign is ProductCampaign && influencer is BloggerInfluencer
                || campaign is ServiceCampaign && influencer is FashionInfluencer
                )
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(campaign.Brand);

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

            if (campaigns.Models.Any(x => x.Brand == brand))
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
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencer in campaign.Contributors)
            {
                IInfluencer currentInfluencer = influencers.FindByName(influencer);

                currentInfluencer.EarnFee(2000);
                currentInfluencer.EndParticipation(brand);
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
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount < 1)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer influencer = null;

            if (typeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(username, followers);
            }
            else if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.Models.Any(x => x.Username == username))
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}