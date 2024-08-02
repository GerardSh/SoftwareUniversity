using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
        }

        public void AddModel(IVehicle model) => models.Add(model);

        public IVehicle FindById(string identifier) => models.FirstOrDefault(x => x.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll() => models;

        public bool RemoveById(string identifier) => models.Remove(FindById(identifier));
    }
}
