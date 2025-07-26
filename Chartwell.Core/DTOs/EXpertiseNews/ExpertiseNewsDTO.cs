using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.EXpertiseNews
{
    public class ExpertiseNewsDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        [Required]
        public string CoverUrl { get; set; }
        [Required]
        public string Category { get; set; }
        public bool IsPublish { get; set; } = true;
        public bool IsDelete { get; set; }
        public string? ClientName { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public int? TeamMemberId { get; set; }
    }
}
