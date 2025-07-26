using Chartwell.Core.Entity.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.TeamMembers
{
    public class TeamMemberToReturnDTOForUsers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string? Bio { get; set; }
        public string PictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? OfficeLocation { get; set; }
        public string? ServiceDepartments { get; set; }
        public string? TeamRoleTitle { get; set; }
        public string? DepartmentServices { get; set; }
    }
}
