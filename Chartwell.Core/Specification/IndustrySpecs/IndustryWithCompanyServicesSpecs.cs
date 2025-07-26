using Chartwell.Core.Entity.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.IndustrySpecs
{
    public class IndustryWithCompanyServicesSpecs : BaseSpecification<Industry>
    {
        public IndustryWithCompanyServicesSpecs(IndustrySpecParams specParams)
            : base(P => (!specParams.CompanyServiceId.HasValue || P.CompanyServiceId == specParams.CompanyServiceId.Value))
        {
            ApplyInclude();
        }


        public IndustryWithCompanyServicesSpecs(int? id) : 
            base(P => P.Id ==id )
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            Include.Add(P => P.CompanyServices);
        }
    }
}
