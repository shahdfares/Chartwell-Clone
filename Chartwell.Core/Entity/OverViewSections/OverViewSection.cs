using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.OverViewSections
{
    public class OverViewSection : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public CompanyExpertise? CompanyExpertise { get; set; }
        public int? CompanyServiceId { get; set; }
        public CompanyServices.CompanyService? CompanyServices { get; set; }
    }
}
