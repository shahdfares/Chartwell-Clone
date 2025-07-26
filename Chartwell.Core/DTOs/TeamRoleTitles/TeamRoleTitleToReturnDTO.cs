using Chartwell.Core.Entity;
using Chartwell.Core.Entity.OurFirms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.TeamRoleTitles
{
    public class TeamRoleTitleToReturnDTO : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? OurFirmId { get; set; }
        public string? OurFirm { get; set; }
    }
}

