using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        List<IRoute> models;

        public RouteRepository()
        {
            models = new List<IRoute>();
        }

        public void AddModel(IRoute model) => models.Add(model);

        public IRoute FindById(string identifier) => models.FirstOrDefault(x => x.RouteId == int.Parse(identifier));

        public IReadOnlyCollection<IRoute> GetAll() => models;

        public bool RemoveById(string identifier) => models.Remove(FindById(identifier));
    }
}
