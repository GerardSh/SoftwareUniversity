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
        private string name;
        List<string> inProgress;

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

        public string Path { get; protected set; }

        public IReadOnlyCollection<string> InProgress => inProgress ?? (inProgress = new List<string>());

        public void FinishTask(string resourceName) => inProgress.Remove(resourceName);

        public void WorkOnTask(string resourceName) => inProgress.Add(resourceName);
    }
}
