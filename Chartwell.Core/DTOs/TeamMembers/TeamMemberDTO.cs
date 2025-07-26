using Chartwell.Core.Entity.Departments;
using Chartwell.Core.Entity.OurFirms;
using Chartwell.Core.Entity.TeamMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.TeamMembers
{
    public class TeamMemberDTO 
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        public string? Bio { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LinkedInUrl { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        public string? Education { get; set; }
        public string? Certifications { get; set; }
        public string? Experience { get; set; }
        public string? OfficeLocation { get; set; }
        public int ServiceDepartmentId { get; set; }
        public string? TeamRoleTitle { get; set; }
        public string? CompanyServices { get; set; }
        public int OurFirmId { get; set; }
    }
}
