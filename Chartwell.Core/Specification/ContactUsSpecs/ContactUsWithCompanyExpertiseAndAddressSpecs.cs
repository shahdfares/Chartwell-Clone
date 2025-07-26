using Chartwell.Core.Entity.ContactsUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.ContactUsSpecs
{
    public class ContactUsWithCompanyExpertiseAndAddressSpecs : BaseSpecification<ContactUs>
    {
        public ContactUsWithCompanyExpertiseAndAddressSpecs(ContactUsSpecParams specParams)
            : base(P => (!specParams.CompanyExpertiseId.HasValue || P.CompanyExpertiseId == specParams.CompanyExpertiseId.Value)&&
                          (!specParams.AddressId.HasValue || P.AddressId == specParams.AddressId.Value))
        {
            ApplyInclude();
        }

        public ContactUsWithCompanyExpertiseAndAddressSpecs(int? id)
            : base(C => C.Id ==  id) 
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            Include.Add(C => C.Address);
            Include.Add(C => C.CompanyExpertise);
        }
    }
}
