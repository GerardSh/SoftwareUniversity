using System.Reflection;
using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        IRepository<IResource> resources;
        IRepository<ITeamMember> members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.TakeOne(resourceName);

            if (!resource.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resource.Name);

                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }

            resource.Test();

            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Presentation) && resourceType != nameof(Workshop))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember member = members.Models.FirstOrDefault(x => x.Path == path);

            if (member == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (member.InProgress.Any(x => x == resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource = null;

            if (resourceType == nameof(Exam))
            {
                resource = new Exam(resourceName, member.Name);
            }
            else if (resourceType == nameof(Presentation))
            {
                resource = new Presentation(resourceName, member.Name);
            }
            else if (resourceType == nameof(Workshop))
            {
                resource = new Workshop(resourceName, member.Name);
            }

            member.WorkOnTask(resourceName);
            resources.Add(resource);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, member.Name, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Finished Tasks:");

            foreach (var resource in resources.Models.Where(x => x.IsApproved))
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine("Team Report:");

            ITeamMember teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            sb.AppendLine("--" + teamLead.ToString());

            foreach (var member in members.Models)
            {
                if (member.GetType().Name == nameof(TeamLead))
                {
                    continue;
                }

                sb.AppendLine(member.ToString());
            }

            return sb.ToString().Trim();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            ITeamMember member = null;

            if (memberType == nameof(TeamLead))
            {
                member = new TeamLead(memberName, path);
            }
            else if (memberType == nameof(ContentMember))
            {
                member = new ContentMember(memberName, path);
            }
            else
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(x => x.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            if (members.Models.Any(x => x.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            members.Add(member);

            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);

            if (member == null)
            {
                return string.Format(OutputMessages.WrongMemberName);
            }

            IResource resource = resources.Models.Where(x => !x.IsTested && x.Creator == memberName).OrderBy(x => x.Priority).FirstOrDefault();

            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            member.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            resource.Test();

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }
    }
}