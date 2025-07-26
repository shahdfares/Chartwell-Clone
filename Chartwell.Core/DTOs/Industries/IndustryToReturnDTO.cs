using Chartwell.Core.Entity.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Industries
{
    public class IndustryToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? IconUrl { get; set; }
        public int? CompanyServiceId { get; set; }
        public string? CompanyServices { get; set; }
    }
}
