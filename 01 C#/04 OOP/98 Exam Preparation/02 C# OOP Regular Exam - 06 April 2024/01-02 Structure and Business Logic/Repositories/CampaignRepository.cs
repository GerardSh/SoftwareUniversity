using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> models;

        public CampaignRepository()
        {
            models = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => models;

        public void AddModel(ICampaign model) => models.Add(model);

        public ICampaign FindByName(string name) => models.FirstOrDefault(x => x.Brand == name);

        public bool RemoveModel(ICampaign model) => models.Remove(model);
    }
}
