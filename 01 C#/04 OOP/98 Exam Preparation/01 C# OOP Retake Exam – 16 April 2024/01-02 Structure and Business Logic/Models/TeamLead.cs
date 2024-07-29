using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        string newPath;

        public TeamLead(string name, string path)
            : base(name, path)
        {
        }

        public override string Path
        {
            get => newPath;
            protected set
            {
                if (value == "Master")
                {
                    newPath = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
                }
            }
        }

        //public TeamLead(string name, string path)
        //    : base(name, path)
        //{
        //}

        //public override string Path
        //{
        //    get => base.Path;
        //    protected set
        //    {
        //        if (value == "Master")
        //        {
        //            base.Path = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
        //        }
        //    }
        //}

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.";
        }
    }
}
