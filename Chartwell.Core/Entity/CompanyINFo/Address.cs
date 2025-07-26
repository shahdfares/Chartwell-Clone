using Chartwell.Core.Entity.ContactsUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.Company
{
    public class Address : BaseEntity
    {
        public string? MainOfficeAddress { get; set; }
        public string? OtherLocations { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? CompanyInfoId { get; set; }
        public CompanyInfo? CompanyInfo { get; set; }


    }
}
