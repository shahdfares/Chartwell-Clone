﻿using Chartwell.Core.Entity.OurFirms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.TeamRoleTitles
{
    public class TeamRoleTitleDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? OurFirmId { get; set; }
       
    }
}
