using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => models;

        public void AddModel(IBooth model) => models.Add(model);
    }
}
