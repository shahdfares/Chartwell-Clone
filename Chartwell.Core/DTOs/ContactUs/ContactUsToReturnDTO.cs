using Chartwell.Core.Entity.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.DTOs.ContactUs
{
    public class ContactUsToReturnDTO
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
        public string? CompanyExpertise { get; set; }
        public int? AddressId { get; set; }
        public string? Address { get; set; }
    }
}
