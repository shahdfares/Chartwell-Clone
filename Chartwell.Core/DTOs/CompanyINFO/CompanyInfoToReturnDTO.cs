using Chartwell.Core.Entity.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.CompanyINFO
{
    public class CompanyInfoToReturnDTO
    {
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string? phoneNumber { get; set; }
        public string? SocialLinks { get; set; }
    }
}
