using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.CompanyServices
{
    public class Industry : AuditableEntity
    {
        public string Name { get; set; }
        public string? IconUrl { get; set; }
        public int? CompanyServiceId { get; set; }
        public CompanyService? CompanyServices { get; set; }
    }
}
