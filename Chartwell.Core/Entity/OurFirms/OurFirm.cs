using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.OurFirms
{
    public class OurFirm : AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PictureUrl { get; set; }
    }
}
