using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.CompanyServices
{
    public class CompanyService : AuditableEntity
    {
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDelete { get; set; }
    }
}
