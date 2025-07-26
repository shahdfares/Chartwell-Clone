using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.Company
{
    public class CompanyInfo : BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? LogoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public SocialLinks SocialLinks { get; set; }                // [ONE TO ONE TOTALL FROM BOTH SIDES]
    }
}
