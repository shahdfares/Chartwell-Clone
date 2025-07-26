using Chartwell.Core.Entity.CompanyServices;
using Chartwell.Core.Entity.ContactsUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.ExpertisesNews
{
    public class CompanyExpertise : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string pictureUrl { get; set; }
        public string? Slug { get; set; }
    }
}
