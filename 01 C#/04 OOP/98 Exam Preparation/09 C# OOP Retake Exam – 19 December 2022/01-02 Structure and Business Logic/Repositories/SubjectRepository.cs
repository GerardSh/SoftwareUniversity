using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        List<ISubject> models;

        public SubjectRepository()
        {
            models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => models;

        public void AddModel(ISubject model) => models.Add(model);

        public ISubject FindById(int id) => models.FirstOrDefault(x => x.Id == id);

        public ISubject FindByName(string name) => models.FirstOrDefault(x=>x.Name == name);
    }
}
