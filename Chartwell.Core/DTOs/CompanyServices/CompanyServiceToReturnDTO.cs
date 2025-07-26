using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.CompanyServices
{
    public class CompanyServiceToReturnDTO
    {
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string PictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
