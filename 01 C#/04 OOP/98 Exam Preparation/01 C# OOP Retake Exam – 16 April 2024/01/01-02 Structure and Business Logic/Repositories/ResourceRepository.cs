using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        readonly List<IResource> models;

        public ResourceRepository()
        {
            this.models = new List<IResource>();
        }

        public IReadOnlyCollection<IResource> Models => models;

        public void Add(IResource model)
        {
            models.Add(model);
        }

        public IResource TakeOne(string modelName) => models.FirstOrDefault(x => x.Name == modelName);
    }
}
