using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.CompanyExpertises
{
    public class ExpertiseNewsToReturnDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int DisplayOrder { get; set; }
        public string CoverUrl { get; set; }
        public string Category { get; set; }
        public bool IsPublish { get; set; } = true;
        public bool IsDelete { get; set; }
        public string? Slug { get; set; }
        public string? ClientName { get; set; }
        public int? CompanyExpertiseId { get; set; }
        public string? CompanyExpertise { get; set; }
        public int? TeamMemberId { get; set; }
        public string? TeamMembers { get; set; }
    }
}
