using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.CompanyServices
{
    public class CompanyServicesDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        [Required]
        public string PictureUrl { get; set; }
    }
}
