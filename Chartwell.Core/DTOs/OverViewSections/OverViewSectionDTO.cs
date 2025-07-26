using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.OverViewSections
{
    public class overViewSectionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string? IconUrl { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public int? CompanyServiceId { get; set; }
    }
}
