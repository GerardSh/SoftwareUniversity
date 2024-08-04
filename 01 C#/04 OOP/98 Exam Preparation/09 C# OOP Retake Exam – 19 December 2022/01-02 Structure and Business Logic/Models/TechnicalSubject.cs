using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        const double SubjectRate = 1.3;

        public TechnicalSubject(int id, string name)
            : base(id, name, SubjectRate)
        {
        }
    }
}
