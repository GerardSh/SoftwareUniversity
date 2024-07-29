using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private readonly List<string> inProgress;

        private string name;
        private string path;

        protected TeamMember(string name, string path)
        {
            Name = name;
            Path = path;

            inProgress = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public virtual string Path
        {
            get => path;
            protected set
            {
                path = value;
            }
        }

        public IReadOnlyCollection<string> InProgress => inProgress;

        public void FinishTask(string resourceName)
        {
            inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            inProgress.Add(resourceName);
        }
    }
}
