using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Specification.ContactUsSpecs
{
    public class ContactUsSpecParams
    {
        public int? CompanyExpertiseId { get; set; }
        public int? AddressId { get; set; }
    }
}
