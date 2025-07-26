using AutoMapper;
using Chartwell.Core.DTOs.ContactUs;
using Chartwell.Core.Entity.ContactsUs;
using Chartwell.Core.RepositoryContract;
using Chartwell.Core.Services.Contract.ContactUsServices;
using Chartwell.Core.Specification.ContactUsSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chartwell.Application.ContactsUsServices
{
    public class ContactUsService : IContactUsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactUsService(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
        public async Task<ContactUs> CreateAsync(ContactUsDTO contactUsDTO)
        {
            if (contactUsDTO is null)
                return null;

            var repo = _unitOfWork.Repository<ContactUs>();

             var contact = _mapper.Map<ContactUs>(contactUsDTO);

            if (contact is null)
                throw new Exception("Mapping Failed");

            await repo.AddAsync(contact);

            await _unitOfWork.CompleteAsync();

            return contact;
             
        }

        public async Task<IReadOnlyList<ContactUsToReturnDTO>> GetAllAsync(ContactUsSpecParams specParams)
        {
            var specs = new ContactUsWithCompanyExpertiseAndAddressSpecs(specParams);

            var allContacts = await _unitOfWork.Repository<ContactUs>().GetAllWithSpecAsync(specs);

            return _mapper.Map<IReadOnlyList<ContactUsToReturnDTO>> (allContacts);

        }

        public async Task<ContactUsToReturnDTO> GetEntityAsync(int? id)
        {
            if (id is null)
                return null;

            var specs = new ContactUsWithCompanyExpertiseAndAddressSpecs(id.Value);

            var entity = await _unitOfWork.Repository<ContactUs>().GetEntityWithSpecs(specs);

            if (entity is null)
                return null;

            return _mapper.Map<ContactUsToReturnDTO>(entity);
        }
    }
}
