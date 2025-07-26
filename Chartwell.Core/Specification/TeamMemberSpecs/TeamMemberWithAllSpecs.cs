using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.TeamMemberSpecs
{
    public class TeamMemberWithAllSpecs : BaseSpecification<TeamMember> 
    {
        public TeamMemberWithAllSpecs(TeamMemberSpecsParams specsParams) :
            base(P =>       (!specsParams.CompanyServiceId.HasValue || P.CompanyServiceId == specsParams.CompanyServiceId.Value) &&
                            (!specsParams.DepartmentServiceId.HasValue || P.DepartmentServiceId == specsParams.DepartmentServiceId.Value) &&
                             (!specsParams.TeamRoleTitleId.HasValue || P.TeamRoleTitleId == specsParams.TeamRoleTitleId.Value) &&
                            (!specsParams.OurFirmId.HasValue || P.OurFirmId == specsParams.OurFirmId.Value))
                                       
        {
            ApplyInclude();
        }

        public TeamMemberWithAllSpecs(int? id) 
            : base(P => P.Id == id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            Include.Add(P => P.CompanyServices);
            Include.Add(P => P.OurFirm);
            Include.Add(P => P.DepartmentServices);
            Include.Add(P => P.TeamRoleTitle);
           
        }
    }
}
