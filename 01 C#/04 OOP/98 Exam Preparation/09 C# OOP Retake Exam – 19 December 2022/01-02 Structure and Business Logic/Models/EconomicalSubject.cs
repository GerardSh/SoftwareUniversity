using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        const double SubjectRate = 1;

        public EconomicalSubject(int id, string name)
            : base(id, name, SubjectRate)
        {
        }
    }
}
