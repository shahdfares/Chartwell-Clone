using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.OurFirms
{
    public class OurFirmToReturnDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
