using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Models
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        List<ITeamMember> models;

        public MemberRepository()
        {
            models = new List<ITeamMember>();
        }

        public IReadOnlyCollection<ITeamMember> Models => models;

        public void Add(ITeamMember model) => models.Add(model);

        public ITeamMember TakeOne(string modelName) => models.FirstOrDefault(x => x.Name == modelName);
    }
}
