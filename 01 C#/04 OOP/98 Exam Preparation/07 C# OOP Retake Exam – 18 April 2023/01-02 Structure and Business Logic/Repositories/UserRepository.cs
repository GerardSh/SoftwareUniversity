using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        List<IUser> models;

        public UserRepository()
        {
            models = new List<IUser>();
        }

        public void AddModel(IUser model) => models.Add(model);

        public IUser FindById(string identifier) => models.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);

        public IReadOnlyCollection<IUser> GetAll() => models;

        public bool RemoveById(string identifier) => models.Remove(FindById(identifier));
    }
}
