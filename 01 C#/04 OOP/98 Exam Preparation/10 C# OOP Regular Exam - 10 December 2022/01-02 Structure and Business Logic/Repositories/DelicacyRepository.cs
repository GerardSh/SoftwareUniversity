using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        List<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => models;

        public void AddModel(IDelicacy model) => models.Add(model);
    }
}
