using Chartwell.Core.Entity;
using Chartwell.Core.Entity.Departments;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.TeamMembers
{
    public class TeamMemberToReturnDTO : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string? Bio { get; set; }
        public string PictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LinkedInUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string? Education { get; set; }
        public string? Certifications { get; set; }
        public string? Experience { get; set; }
        public bool IsDelete { get; set; }
        public string? OfficeLocation { get; set; }
        public string? Slug { get; set; }
        public int? DepartmentServiceId { get; set; }
        public string? DepartmentServices { get; set; }
        public int? TeamRoleTitleId { get; set; }
        public string? TeamRoleTitle { get; set; }
        public int? CompanyServiceId { get; set; }
        public string? CompanyServices { get; set; }
        public int? OurFirmId { get; set; }
        public string? OurFirm { get; set; }
    }
}
