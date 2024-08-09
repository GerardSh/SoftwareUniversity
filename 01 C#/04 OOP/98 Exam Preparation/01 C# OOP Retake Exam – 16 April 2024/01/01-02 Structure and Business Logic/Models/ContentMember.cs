using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path)
            : base(name, path)
        {
        }

        public override string Path
        {
            get => base.Path;
            protected set
            {
                if (value == "CSharp" || value == "JavaScript" || value == "Python" || value == "Java")
                {
                    base.Path = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
