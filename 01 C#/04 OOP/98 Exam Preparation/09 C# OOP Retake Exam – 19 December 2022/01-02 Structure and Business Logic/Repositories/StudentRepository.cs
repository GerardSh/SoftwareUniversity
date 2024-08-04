using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models;

        public void AddModel(IStudent model) => models.Add(model);

        public IStudent FindById(int id) => models.FirstOrDefault(x => x.Id == id);

        public IStudent FindByName(string name) => models.FirstOrDefault(x => x.FirstName == name.Split()[0] && x.LastName == name.Split()[1]);
    }
}
