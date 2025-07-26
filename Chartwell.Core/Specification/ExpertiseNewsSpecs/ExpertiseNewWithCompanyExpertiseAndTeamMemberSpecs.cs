using Chartwell.Core.Entity.ExpertisesNews;
using Chartwell.Core.Specification.OverViewSpecs;
using Chartwell.Core.Specification.SubIndustrySpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.ExpertiseNewsSpecs
{
    public class ExpertiseNewWithCompanyExpertiseAndTeamMemberSpecs : BaseSpecification<ExpertiseNews>
    {
        public ExpertiseNewWithCompanyExpertiseAndTeamMemberSpecs(ExpertiseNewsSpecParams specParams)
           : base(P => (!specParams.CompanyExpertiseId.HasValue || P.CompanyExpertiseId == specParams.CompanyExpertiseId.Value)&&
                       (!specParams.TeamMemberId.HasValue || P.TeamMemberId == specParams.TeamMemberId.Value))
        {
            ApplyInclude();
        }

        public ExpertiseNewWithCompanyExpertiseAndTeamMemberSpecs(int? id)
            : base(P => P.Id == id)
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            Include.Add(P => P.CompanyExpertise);
            Include.Add(P => P.TeamMembers);
        }
    }
}
