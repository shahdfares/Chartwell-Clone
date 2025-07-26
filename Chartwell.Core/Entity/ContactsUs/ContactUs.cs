using Chartwell.Core.Entity.Company;
using Chartwell.Core.Entity.ExpertisesNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Entity.ContactsUs
{
    public class ContactUs : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string? PictureUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public bool IsReplied { get; set; } = false;
        public int? CompanyExpertiseId { get; set; }
        public CompanyExpertise? CompanyExpertise { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
