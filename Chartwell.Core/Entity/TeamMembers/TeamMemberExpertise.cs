using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chartwell.Core.Entity.ExpertisesNews;

namespace Chartwell.Core.Entity.TeamMembers
{
    public class TeamMemberExpertise
    {
        public int? TeamMemberId { get; set; }
        public TeamMember? TeamMembers { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public CompanyExpertise? CompanyExpertises { get; set; }

        public int DisplayOrder { get; set; }
        public string RoleTitle { get; set; }
    }
}
