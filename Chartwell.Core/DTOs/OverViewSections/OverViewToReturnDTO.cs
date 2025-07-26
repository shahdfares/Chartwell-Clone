using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.OverViewSections
{
    public class OverViewToReturnDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public string CompanyExpertise { get; set; }
        public int? CompanyServiceId { get; set; }
        public string CompanyServices { get; set; }
    }
}
