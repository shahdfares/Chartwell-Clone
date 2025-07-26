using Chartwell.Core.Entity.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.SubIndustrySpecs
{
    public class SubIndustryWithIndustrySpecs : BaseSpecification<SubIndustry>
    {
        public SubIndustryWithIndustrySpecs(SubIndustrySpecParams specParams) 
            : base (P => (!specParams.IndustryId.HasValue || P.IndustryId == specParams.IndustryId.Value))
        {
            ApplyInclude();
        }

        public SubIndustryWithIndustrySpecs(int? id)
            : base(P => P.Id == id)
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            Include.Add(P => P.Industries);
        }
    }
}
