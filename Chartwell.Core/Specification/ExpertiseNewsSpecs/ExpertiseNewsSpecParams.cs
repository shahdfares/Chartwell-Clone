using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.ExpertiseNewsSpecs
{
    public class ExpertiseNewsSpecParams 
    {
        public int? CompanyExpertiseId { get; set; }      
        public int? TeamMemberId { get; set; }
    }
}
