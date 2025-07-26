using Chartwell.Core.Entity.OurFirms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.TeamMembers
{
    public class TeamRoleTitle : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? OurFirmId { get; set; }
        public OurFirm? OurFirm { get; set; }
    }
}
