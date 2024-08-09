using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        ResourceRepository resources;
        MemberRepository members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.Models.FirstOrDefault(x => x.Name == resourceName);

            if (!resource.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            var teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);

                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }

            resource.Test();

            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            IResource resource = null;

            if (resourceType != nameof(Exam) && resourceType != nameof(Workshop) && resourceType != nameof(Presentation))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            var member = members.Models.FirstOrDefault(x => x.Path == path);

            if (member == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (member.InProgress.Any(x => x == resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            if (resourceType == nameof(Exam))
            {
                resource = new Exam(resourceName, member.Name);
            }
            else if (resourceType == nameof(Workshop))
            {
                resource = new Workshop(resourceName, member.Name);
            }
            else if (resourceType == nameof(Presentation))
            {
                resource = new Presentation(resourceName, member.Name);
            }

            member.WorkOnTask(resourceName);

            resources.Add(resource);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, member.Name, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            var sb = new StringBuilder();

            var teamlead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            var teamMembers = members.Models.Where(x => x.Name != teamlead.Name);

            sb.AppendLine("Finished Tasks:");

            foreach (var resource in resources.Models.Where(x => x.IsApproved))
            {
                sb.AppendLine("--" + resource.ToString());
            }

            sb.AppendLine("Team Report:");
            sb.AppendLine("--" + teamlead.ToString());

            foreach (var member in teamMembers)
            {
                sb.AppendLine(member.ToString());
            }

            return sb.ToString().Trim();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            ITeamMember teamMember = null;

            if (memberType == nameof(ContentMember))
            {
                teamMember = new ContentMember(memberName, path);
            }
            else if (memberType == nameof(TeamLead))
            {
                teamMember = new TeamLead(memberName, path);
            }
            else
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(x => x.Path == path))
            {
                return OutputMessages.PositionOccupied;
            }

            if (members.Models.Any(x => x.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            members.Add(teamMember);

            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            var member = members.TakeOne(memberName);

            if (member == null)
            {
                return OutputMessages.WrongMemberName;
            }

            var resource = resources.Models.OrderBy(x => x.Priority).Where(x => x.IsTested == false && x.Creator == member.Name).FirstOrDefault();

            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            resource.Test();

            var teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            member.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }
    }
}
