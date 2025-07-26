using Chartwell.Core.Entity.OverViewSections;
using Chartwell.Core.Specification.TeamMemberSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.OverViewSpecs
{
    public class OverViewWithCompanyExpertiseAndServiceSpecs : BaseSpecification<OverViewSection>
    {
        public OverViewWithCompanyExpertiseAndServiceSpecs(OverViewSpecsParams specsParams) :
             base(P => (!specsParams.CompanyServiceId.HasValue || P.CompanyServiceId == specsParams.CompanyServiceId.Value) &&
                            (!specsParams.CompanyExpertiseId.HasValue || P.CompanyExpertiseId == specsParams.CompanyExpertiseId.Value))
                       
                           
        {
            ApplyInclude();
        }

        public OverViewWithCompanyExpertiseAndServiceSpecs(int? id)
           : base(P => P.Id == id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            Include.Add(P => P.CompanyServices);
            Include.Add(P => P.CompanyExpertise);
        }
    }
}
