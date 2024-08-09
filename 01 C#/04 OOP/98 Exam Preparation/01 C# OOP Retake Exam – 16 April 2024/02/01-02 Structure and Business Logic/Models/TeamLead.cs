using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        public TeamLead(string name, string path)
            : base(name, path)
        {
            if (path != "Master")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }

        public override string ToString()
        {                                      
            return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.";
        }
    }
}
