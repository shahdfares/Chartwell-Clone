using Chartwell.Core.Entity.CompanyServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.SubIndustries
{
    public class SubIndustryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public int? IndustryId { get; set; }
        
    }
}
