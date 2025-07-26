using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.Industries
{
    public class IndustryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? IconUrl { get; set; }
        public int? CompanyServiceId { get; set; }
    }
}
