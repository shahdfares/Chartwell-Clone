using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.CompanyServices
{
    public class SubIndustry : AuditableEntity
    {
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public int? IndustryId { get; set; }
        public Industry? Industries { get; set; }
    }
}
