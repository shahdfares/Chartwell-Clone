using Chartwell.Core.DTOs.ContactUs;
using Chartwell.Core.Entity.ContactsUs;
using Chartwell.Core.Specification.ContactUsSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Core.Services.Contract.ContactUsServices
{
    public interface IContactUsService
    {
        Task<ContactUs> CreateAsync(ContactUsDTO contactUsDTO);
        Task<IReadOnlyList<ContactUsToReturnDTO>> GetAllAsync(ContactUsSpecParams specParams);
        Task<ContactUsToReturnDTO> GetEntityAsync(int? id);
    }
}
